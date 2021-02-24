using IRestaurant.DAL.DTO.Order;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<OrderOverviewDto>> GetUserOrders(string userId);
        Task<IReadOnlyCollection<OrderOverviewDto>> GetOrdersBelongsToRestaurant(int restaurantId);
        Task<OrderDto> GetOrderOrNull(int orderId);
        Task<OrderDto> CreateOrder(string userId, CreateOrder order);
        Task ChangeOrderStatus(int orderId, Status status);
    }
}
