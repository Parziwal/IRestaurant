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

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetGuestOrderOverviews()
        {
            string userId = userRepository.GetCurrentUserId();
            return await orderRepository.GetGuestOrderOverviews(userId);
        }

        public async Task<IReadOnlyCollection<OrderOverviewDto>> GetOrdersBelongsToMyRestaurant()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetUserRestaurantId(userId);

            return await orderRepository.GetOrderOverviewBelongsToRestaurant(ownerRestaurantId);
        }

        public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
        {
            string userId = userRepository.GetCurrentUserId();
            string orderUserId = await orderRepository.GetOrderUserId(orderId);
            int userRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetUserRestaurantId(userId) : -1;
            int orderRestaurantId = await orderRepository.GetOrderRestaurantId(orderId);

            if (userId == orderUserId || userRestaurantId == orderRestaurantId)
            {
                return await orderRepository.GetOrderDetails(orderId);
            }
            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés megtekintéséhez nincs jogosultságod");
        }

        public async Task<OrderDetailsDto> CreateOrder(CreateOrder order)
        {
            string userId = userRepository.GetCurrentUserId();
            return await orderRepository.CreateOrder(userId, order);
        }

        public async Task ChangeOrderStatus(int orderId, OrderStatus status)
        {
            OrderStatus orderStatus = await orderRepository.GetOrderStatus(orderId);
            if (status == OrderStatus.CANCELLED && orderStatus == OrderStatus.PROCESSING)
            {
                await orderRepository.ChangeOrderStatus(orderId, status);
                return;
            }

            string userId = userRepository.GetCurrentUserId();
            int userRestaurantId = await userRepository.GetUserRestaurantId(userId);
            int orderRestaurantId = await orderRepository.GetOrderRestaurantId(orderId);

            if (userRestaurantId == orderRestaurantId &&
                orderStatus < status && orderStatus != OrderStatus.CANCELLED)
            {
                await orderRepository.ChangeOrderStatus(orderId, status);
                return;
            }
            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés státuszának megváltoztatásához nincs jogosultságod," +
                "vagy egy korábbi állapotba való visszaálítása nem lehetséges.");
        }
    }
}
