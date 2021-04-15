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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IInvoiceRepository invoiceRepository;
        public OrderRepository(ApplicationDbContext dbContext, IInvoiceRepository invoiceRepository)
        {
            this.dbContext = dbContext;
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetGuestOrderOverviews(string userId)
        {
            return await dbContext.Orders
                .Where(o => o.UserId == userId)
                .ToOrderOverviewDtoList();
        }
        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrderOverviewBelongsToRestaurant(int restaurantId)
        {
            return await dbContext.Orders
                .Where(o => o.OrderFoods.First().Food.RestaurantId == restaurantId)
                .ToOrderOverviewDtoList();
        }
        public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();
            
            return await dbContext.Entry(dbOrder).ToOrderDetailsDto();
        }

        public async Task<OrderDetailsDto> CreateOrder(string userId, CreateOrder order)
        {
            var dbOrder = new Order
            {
                Date = DateTime.Now,
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

        public async Task ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            dbOrder.Status = status;
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetOrderUserId(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.UserId;
        }

        public async Task<int> GetOrderRestaurantId(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .Include(o => o.OrderFoods)
                            .ThenInclude(of => of.Food)
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.OrderFoods.First().Food.RestaurantId;
        }

        public async Task<OrderStatus> GetOrderStatus(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();
            return dbOrder.Status;
        }
    }
    internal static class OrderRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<OrderOverviewDto>> ToOrderOverviewDtoList(this IQueryable<Order> orders)
        {
            return await orders
                        .Include(o => o.OrderFoods)
                        .Include(o => o.Invoice)
                        .Select(o => new OrderOverviewDto(o)).ToListAsync();
        }

        public static async Task<OrderDetailsDto> ToOrderDetailsDto(this EntityEntry<Order> order)
        {
            await order.Reference(o => o.Invoice).LoadAsync();
            await order.Collection(o => o.OrderFoods).Query()
                        .Include(of => of.Food).LoadAsync();
            return new OrderDetailsDto(order.Entity);
        }

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
