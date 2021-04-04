using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BL.Managers
{
    public class OrderManager
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        public OrderManager(IOrderRepository orderRepository,
            IUserRepository userRepository)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetUserOrders()
        {
            string userId = userRepository.GetCurrentUserId();
            return await orderRepository.GetUserOrderOverviews(userId);
        }

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrdersBelongsToMyRestaurant()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            return await orderRepository.GetOrderOverviewBelongsToRestaurant(ownerRestaurantId);
        }

        public async Task<OrderDto> GetOrderDetails(int orderId)
        {
            string userId = userRepository.GetCurrentUserId();
            string orderUserId = await orderRepository.GetOrderUserId(orderId);

            if (userId == orderUserId)
            {
                return await orderRepository.GetOrderDetails(orderId);
            }
            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés megtekintéséhez nincs jogosultságod");
        }

        public async Task<OrderDto> CreateOrder(CreateOrder order)
        {
            string userId = userRepository.GetCurrentUserId();
            return await orderRepository.CreateOrder(userId, order);
        }

        public async Task ChangeOrderStatus(int orderId, Status status)
        {
            string userId = userRepository.GetCurrentUserId();
            int userRestaurantId = await GetUserRestaurantId(userId);
            int orderRestaurantId = await orderRepository.GetOrderRestaurantId(orderId);

            if (userRestaurantId == orderRestaurantId)
            {
                await orderRepository.ChangeOrderStatus(orderId, status);
                return;
            }
            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés státuszának megváltoztatásához nincs jogosultságod");
        }

        private async Task<int> GetUserRestaurantId(string userId)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "A felhasználóhoz étterem nem található.");
            }

            return (int)ownerRestaurantId;
        }
    }
}
