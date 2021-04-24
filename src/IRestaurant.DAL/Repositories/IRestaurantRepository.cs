using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRestaurant.DAL;
using IRestaurant.DAL.DTO;
using IRestaurant.DAL.DTO.Restaurants;

namespace IRestaurant.DAL.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviewList(string restaurantName = null);
        Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId);
        Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId);
        Task<RestaurantDetailsDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant);
        Task<string> UploadRestaurantImage(int restaurantId, UploadImageDto uploadedImage);
        Task DeleteRestaurantImage(int restaurantId);
        Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId);
        Task ChangeShowForUsersStatus(int restaurantId, bool value);
        Task ChangeOrderAvailableStatus(int restaurantId, bool value);
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurantList(string userId, string restaurantName = null);
        Task AddRestaurantToUserFavourite(int restaurantId, string userId);
        Task RemoveRestaurantFromUserFavourite(int restaurantId, string userId);
        Task<bool> IsThisRestaurantGuestFavourite(int restaurantId, string guestId);
    }
}
