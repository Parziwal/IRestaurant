using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Hellang.Middleware.ProblemDetails;

namespace IRestaurant.BL
{
    public class RestaurantManager
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        public RestaurantManager(IRestaurantRepository restaurantRepository,
            IUserRepository userRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(string restaurantName = null)
        {
            return await restaurantRepository.GetRestaurantOverviews(restaurantName);
        }

        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            if (!await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest, "A megadott azonosítóval rendelkező étterem jelenleg nem elérhető.");
            }
            var restaurant = await restaurantRepository.GetRestaurantDetails(restaurantId);

            return restaurant;
        }
        public async Task<RestaurantDetailsDto> GetMyRestaurant()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            var restaurant = await restaurantRepository.GetRestaurantDetails(ownerRestaurantId);
            if (restaurant == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "Az étterem nem található.");
            }
            return restaurant;
        }
        public async Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<RestaurantDetailsDto> EditMyRestaurant(EditRestaurantDto editRestaurant)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            return await restaurantRepository.EditRestaurant(ownerRestaurantId, editRestaurant);
        }
        public async Task<RestaurantSettingsDto> GetMyRestaurantSettings()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            return await restaurantRepository.GetRestaurantSettings(ownerRestaurantId);
        }

        public async Task ChangeMyRestaurantShowStatus(bool value)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            await checkIfRestaurantDataNotEmpty(ownerRestaurantId);

            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus(ownerRestaurantId, value);
                await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, value);

                transaction.Complete();
            }
        }

        public async Task ChangeMyRestaurantOrderStatus(bool value)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);
            
            await checkIfRestaurantDataNotEmpty(ownerRestaurantId);
            await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, value);
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurants()
        {
            string userId = userRepository.GetCurrentUserId();
            return await restaurantRepository.GetUserFavouriteRestaurants(userId);
        }

        public async Task AddRestaurantToUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.AddRestaurantToUserFavourite(restaurantId, userId);
        }

        public async Task RemoveRestaurantFromUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.RemoveRestaurantFromUserFavourite(restaurantId, userId);
        }

        private async Task checkIfRestaurantDataNotEmpty(int restaurantId)
        {
            var restaurant = await restaurantRepository.GetRestaurantDetails(restaurantId);

            if (string.IsNullOrEmpty(restaurant.Name)
                || string.IsNullOrEmpty(restaurant.ShortDescription)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.City)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.Street)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.PhoneNumber))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "Az étterem elérhetővé tétele és/vagy a rendelési lehetőség engedélyezése nem lehetséges, amíg a kötelező adatok nem kerülnek kitöltésre.");
            }
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
