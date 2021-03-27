using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRestaurant.DAL;
using IRestaurant.DAL.DTO.Restaurants;

namespace IRestaurant.DAL.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(string restaurantName = null);
        Task<RestaurantDto> GetRestaurant(int restaurantId);
        Task<RestaurantDto> CreateDefaultRestaurant(string ownerId);
        Task<RestaurantDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant);
        Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId);
        Task ChangeShowForUsersStatus(int restaurantId, bool value);
        Task ChangeOrderAvailableStatus(int restaurantId, bool value);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurants(string userId);
        Task AddRestaurantToUserFavourite(int restaurantId, string userId);
        Task RemoveRestaurantFromUserFavourite(int restaurantId, string userId);
    }
}
