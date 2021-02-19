using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRestaurant.DAL;
using IRestaurant.DAL.DTO;

namespace IRestaurant.DAL.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<RestaurantOverviewDto>> ListRestaurantOverviews(string restaurantName = null);
        Task<RestaurantDto> GetRestaurantOrNull(int restaurantId);
        Task<RestaurantDto> CreateDefaultRestaurant(string ownerId);
        Task<RestaurantDto> EditRestaurant(string ownerId, EditRestaurantDto editRestaurant);
        Task<bool> ChangeShowForUsersStatus(string ownerId, bool value);
        Task<bool> ChangeOrderAvailableStatus(string ownerId, bool value);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
        Task<bool> UserOwnsThisRestaurant(string ownerId, int restaurantId);
    }
}
