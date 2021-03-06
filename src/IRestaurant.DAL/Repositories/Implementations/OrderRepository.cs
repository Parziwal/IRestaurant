using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetUserOrders(string userId)
        {
            return await dbContext.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Invoice)
                .Include(o => o.OrderFoods)
                .GetOrders();
        }
        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrdersBelongsToRestaurant(int restaurantId)
        {
            return await dbContext.Orders
                .Where(o => o.OrderFoods.First().Food.RestaurantId == restaurantId)
                .Include(o => o.Invoice)
                .Include(o => o.OrderFoods)
                .GetOrders();
        }
        public async Task<OrderDto> GetOrderOrNull(int orderId)
        {
            var dbOrder = await dbContext.Orders
                            .Include(o => o.Invoice)
                            .Include(o => o.OrderFoods.Select(of => of.Food))
                            .SingleOrDefaultAsync(o => o.Id == orderId);

            return dbOrder?.GetOrder();
        }

        public async Task<OrderDto> CreateOrder(string userId, CreateOrder order)
        {
            var dbOrder = new Order {
                Date = DateTime.Now,
                PreferredDeliveryDate = order.PreferredDeliveryDate,
                Status = Status.PROCESSING,
                UserId = userId
            };

            await dbContext.Orders.AddAsync(dbOrder);
            await dbContext.SaveChangesAsync();

            foreach (var orderFood in order.OrderFoods)
            {
                var dbFood = await dbContext.Foods
                    .SingleOrDefaultAsync(f => f.Id == orderFood.FoodId && f.RestaurantId == order.RestaurantId);

                if (dbFood == null)
                {
                    continue;
                }

                var newOrderFood = new OrderFood
                {
                    Amount = orderFood.Amount,
                    Price = dbFood.Price,
                    OrderId = dbOrder.Id,
                    FoodId = orderFood.FoodId,
                };
                await dbContext.OrderFoods.AddAsync(newOrderFood);
            }
            await dbContext.SaveChangesAsync();

            await invoiceRepository.CreateInvoice(order.AddressId, order.RestaurantId);

            return await GetOrderOrNull(dbOrder.Id);
        }

        public async Task ChangeOrderStatus(int orderId, Status status)
        {
            var dbOrder = await dbContext.Orders
                .SingleOrDefaultAsync(o => o.Id == orderId);

            if (dbOrder == null)
            {
                return;
            }

            dbOrder.Status = status;

            await dbContext.SaveChangesAsync();
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
            return order.OrderFoods.Sum(of => of.Price);
        }
    }
}
