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

        public async Task<RestaurantDto> GetRestaurant(int restaurantId)
        {
            var restaurant = await restaurantRepository.GetRestaurantOrNull(restaurantId);
            if (!await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId)
                || restaurant == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "Az étterem jelenleg nem elérhető, vagy nem is létezik.");
            }

            return restaurant;
        }
        public async Task<RestaurantDto> GetMyRestaurant()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            var restaurant = await restaurantRepository.GetRestaurantOrNull(ownerRestaurantId);
            if (restaurant == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "Az étterem nem található.");
            }
            return restaurant;
        }
        public async Task<RestaurantDto> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<RestaurantDto> EditMyRestaurant(EditRestaurantDto editRestaurant)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            try
            {
                return await restaurantRepository.EditRestaurant(ownerRestaurantId, editRestaurant);
            }
            catch(ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
            } 
        }
        public async Task ChangeMyRestaurantShowStatus(bool value)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            try
            {
                using (var transaction = new TransactionScope(
                  TransactionScopeOption.Required,
                  new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                  TransactionScopeAsyncFlowOption.Enabled))
                {
                    await restaurantRepository.ChangeShowForUsersStatus(ownerRestaurantId, value);
                    await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, value);

                    transaction.Complete();
                }
            } catch(ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
            }
        }

        public async Task ChangeMyRestaurantOrderStatus(bool value)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await GetUserRestaurantId(userId);

            try
            {
                await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, value);
            }
            catch (ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
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
