﻿using IRestaurant.DAL.DTO.Orders;
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
        Task<IReadOnlyCollection<OrderOverviewDto>> GetGuestOrderOverviews(string userId);
        Task<IReadOnlyCollection<OrderOverviewDto>> GetOrderOverviewBelongsToRestaurant(int restaurantId);
        Task<OrderDetailsDto> GetOrderDetails(int orderId);
        Task<OrderDetailsDto> CreateOrder(string userId, CreateOrder order);
        Task ChangeOrderStatus(int orderId, OrderStatus status);
        Task<string> GetOrderUserId(int orderId);
        Task<int> GetOrderRestaurantId(int orderId);
        Task<OrderStatus> GetOrderStatus(int orderId);
    }
}
