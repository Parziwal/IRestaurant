using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// A rendeléshez kapcsolódó adatokon való műveletek elvégzéséért és az adatok lekéréséért felelős.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IInvoiceRepository invoiceRepository;

        /// <summary>
        /// Az adatbázis és a számlázási repository inicializációja a konstruktorban.
        /// </summary>
        /// <param name="dbContext">Az adatbázis.</param>
        /// <param name="invoiceRepository">A számlázást kezelő repository.</param>
        public OrderRepository(ApplicationDbContext dbContext, IInvoiceRepository invoiceRepository)
        {
            this.dbContext = dbContext;
            this.invoiceRepository = invoiceRepository;
        }

        /// <summary>
        /// A megadott vendéghez tartozó rendelések listájánal lekérése.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <returns>A vendég rendelései.</returns>
        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetGuestOrderOverviewList(string guestId)
        {
            return await dbContext.Orders
                .Where(o => o.UserId == guestId)
                .ToOrderOverviewDtoList();
        }

        /// <summary>
        /// A megadott étteremhez tartozó rendelések listájánal lekérése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>A rendelések listája.</returns>
        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetRestaurantOrderOverviewList(int restaurantId)
        {
            return await dbContext.Orders
                .Where(o => o.OrderFoods.First().Food.RestaurantId == restaurantId)
                .ToOrderOverviewDtoList();
        }

        /// <summary>
        /// A rendelés részletes adatainak lekérése.
        /// Ha a megadott azonosítóval rendelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="orderId">A rendelés azonosízója.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();
            
            return await dbContext.Entry(dbOrder).ToOrderDetailsDto();
        }

        /// <summary>
        /// A megadott adatok alapján a rendelés létrehozása.
        /// A rendelés létrehozása során ellenőrizzük, hogy tartalmaz-e egyátalán tételeket a rendelés,
        /// és, hogy a tételben szereplő ételek léteznek-e, mert ha nem akkor ezt kivételben jelezzük.
        /// Ha pedig minden rendben ment létrehozzuk a rendeléshez tartozó számlát és visszatérünk a
        /// reészletes adatokkal.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <param name="order">A rendelés adatait tartalmazó objektum.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        public async Task<OrderDetailsDto> CreateOrder(string userId, CreateOrder order)
        {
            if (!order.OrderFoods.Any())
            {
                throw new EntityNotFoundException("A rendelésben egyetlen tétel sem szerepel.");
            }

            var dbOrder = new Order
            {
                CreatedAt = DateTime.Now,
                PreferredDeliveryDate = order.PreferredDeliveryDate,
                Status = OrderStatus.PROCESSING,
                UserId = userId
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                 new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                 TransactionScopeAsyncFlowOption.Enabled))
            {
                await dbContext.Orders.AddAsync(dbOrder);

                foreach (var orderFood in order.OrderFoods)
                {
                    var dbFood = (await dbContext.Foods
                        .SingleOrDefaultAsync(f => f.Id == orderFood.FoodId && f.RestaurantId == order.RestaurantId))
                        .CheckIfFoodNull("A rendelésben szereplő étteremhez a megadott ételek közül egy vagy több nem található.");

                    var newOrderFood = new OrderFood
                    {
                        Amount = orderFood.Amount,
                        Price = dbFood.Price,
                        Order = dbOrder,
                        Food = dbFood,
                    };
                    await dbContext.OrderFoods.AddAsync(newOrderFood);
                }
                await dbContext.SaveChangesAsync();

                await invoiceRepository.CreateInvoice(dbOrder.Id, order.RestaurantId, order.AddressId);

                transaction.Complete();
            }

            return await dbContext.Entry(dbOrder).ToOrderDetailsDto();
        }

        /// <summary>
        /// A rendelés státuszának módosítása.
        /// Ha a megadott azonosítóval rendelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <param name="status">A státusz, amire módosítjuk.</param>
        public async Task ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            dbOrder.Status = status;
            await dbContext.SaveChangesAsync();
        }


        /// <summary>
        /// A rendeléshez tartozó felhasználói azonosító lekérése.
        /// Ha a megadott azonosítóval rendelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A felhasználó azonosítója.</returns>
        public async Task<string> GetOrderUserId(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.UserId;
        }

        /// <summary>
        /// Az étterem azonosítójának lekérdezése, amihez a rendelés tartozik.
        /// Ha a megadott azonosítóval rendelés nem található, akkor kivételt dobunk.
        /// Az étterem maga az ételen keresztül érhető el, amit a rendelési tétel tartalmaz.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>Az étterem azonosítója.</returns>
        public async Task<int> GetOrderRestaurantId(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .IgnoreQueryFilters()
                            .Include(o => o.OrderFoods)
                            .ThenInclude(of => of.Food)
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.OrderFoods.First().Food.RestaurantId;
        }

        /// <summary>
        /// A rendelés stétuszának lekérdezése.
        /// Ha a megadott azonosítóval rendelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A rendelés státusza.</returns>
        public async Task<OrderStatus> GetOrderStatus(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();
            return dbOrder.Status;
        }
    }

    /// <summary>
    /// Az rendeléshez kapcsolódó extension metódusok.
    /// </summary>
    internal static class OrderRepositoryExtensions
    {
        /// <summary>
        /// A rendelés típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="orders">Rendelés típusú lekérdezés.</param>
        /// <returns>Áttekintő rendelési adatokat tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<OrderOverviewDto>> ToOrderOverviewDtoList(this IQueryable<Order> orders)
        {
            return await orders
                        .Include(o => o.OrderFoods)
                        .Include(o => o.Invoice)
                        .Select(o => new OrderOverviewDto(o)).ToListAsync();
        }

        /// <summary>
        /// A rendelés modell osztály átalakítása részletes adatokat tartalmazó adatátviteli objektummá.
        /// </summary>
        /// <param name="order">Rendelés típusú entitás.</param>
        /// <returns>A rendelés részletes adatait tartalmazó adatátviteli objektum.</returns>
        public static async Task<OrderDetailsDto> ToOrderDetailsDto(this EntityEntry<Order> order)
        {
            await order.Reference(o => o.Invoice).LoadAsync();
            await order.Collection(o => o.OrderFoods).Query()
                        .Include(of => of.Food).LoadAsync();
            return new OrderDetailsDto(order.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott rendelés típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="order">Rendelés típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Rendelés típusú modell osztály.</returns>
        public static Order CheckIfOrderNull(this Order order,
            string errorMessage = "A rendelés nem található.")
        {
            if (order == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return order;
        }
    }
}
