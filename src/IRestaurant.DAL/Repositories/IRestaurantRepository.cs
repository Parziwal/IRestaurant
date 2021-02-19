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
        Task<DTO.Restaurant> CreateDefaultRestaurant(string ownerId);
        Task<DTO.Restaurant> EditRestaurant(string ownerId, DTO.EditRestaurant editRestaurant);
        Task<bool> ChangeShowForUsersStatus(string ownerId, bool value);
        Task<bool> ChangeOrderAvailableStatus(string ownerId, bool value);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
        Task<bool> UserOwnsThisRestaurant(string ownerId, int restaurantId);
    }
}
