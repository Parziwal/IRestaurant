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
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(string restaurantName = null);
        Task<RestaurantDto> GetRestaurantOrNull(int restaurantId);
        Task<RestaurantDto> CreateDefaultRestaurant(string ownerId);
        Task<RestaurantDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant);
        Task ChangeShowForUsersStatus(int restaurantId, bool value);
        Task ChangeOrderAvailableStatus(int restaurantId, bool value);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
    }
}
