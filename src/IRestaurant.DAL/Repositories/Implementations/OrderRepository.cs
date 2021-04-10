using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
                .Include(o => o.Invoice)
                .Include(o => o.OrderFoods)
                .GetOrders();
        }
        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrderOverviewBelongsToRestaurant(int restaurantId)
        {
            return await dbContext.Orders
                .Where(o => o.OrderFoods.First().Food.RestaurantId == restaurantId)
                .Include(o => o.Invoice)
                .Include(o => o.OrderFoods)
                .GetOrders();
        }
        public async Task<OrderDto> GetOrderDetails(int orderId)
        {
            var dbOrder = (await dbContext.Orders
                            .Include(o => o.Invoice)
                            .Include(o => o.OrderFoods)
                            .ThenInclude(of => of.Food)
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.GetOrder();
        }

        public async Task<OrderDto> CreateOrder(string userId, CreateOrder order)
        {
            var dbOrder = new Order
            {
                Date = DateTime.Now,
                PreferredDeliveryDate = order.PreferredDeliveryDate,
                Status = Status.PROCESSING,
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
           

            return await GetOrderDetails(dbOrder.Id);
        }

        public async Task ChangeOrderStatus(int orderId, Status status)
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
                            .SingleOrDefaultAsync(o => o.Id == orderId))
                            .CheckIfOrderNull();

            return dbOrder.OrderFoods.First().Food.RestaurantId;
        }
    }
    internal static class OrderRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrders(this IQueryable<Order> orders)
        {
            return await orders.Select(o => new OrderOverviewDto(o, CalculateOrderTotal(o), o.Invoice)).ToListAsync();
        }

        public static OrderDto GetOrder(this Order order)
        {
            return new OrderDto(order, CalculateOrderTotal(order), order.Invoice, order.OrderFoods);
        }

        private static int CalculateOrderTotal(Order order)
        {
            return order.OrderFoods.Sum(of => of.Price * of.Amount);
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
