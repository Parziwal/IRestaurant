using System;
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
        Task<DTO.Restaurant> CreateDeafaultRestaurant(string ownerId);
        Task<DTO.Restaurant> EditRestaurant(int restaurantId, DTO.EditRestaurant editRestaurant);
        Task<DTO.Restaurant> ShowRestaurantForUsers(int restaurantId);
        Task<DTO.Restaurant> HideRestaurantFromUsers(int restaurantId);
        Task<DTO.Restaurant> TurnOnOrderOption(int restaurantId);
        Task<DTO.Restaurant> TurnOffOrderOption(int restaurantId);
        Task<bool> IsAllRestaurantDataGiven(int restaurantId);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
    }
}
