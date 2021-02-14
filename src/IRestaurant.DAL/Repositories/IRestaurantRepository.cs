﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRestaurant.DAL;

namespace IRestaurant.DAL.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<DTO.RestaurantOverview>> ListRestaurantOverviews(string restaurantName = null);
        Task<DTO.Restaurant> GetRestaurantOrNull(int restaurantId);
        Task<DTO.Restaurant> InsertDeafaultRestaurant(string ownerId);
        Task<DTO.Restaurant> EditRestaurant(int restaurantId, DTO.EditRestaurant editRestaurant);
        Task<bool> ShowRestaurantForUsers(int restaurantId);
        Task<bool> HideRestaurantFromUsers(int restaurantId);
        Task<DTO.Restaurant> TurnOnOrderOption(int restaurantId);
        Task<DTO.Restaurant> TurnOffOrderOption(int restaurantId);
    }
}