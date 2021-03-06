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
            int? userRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            if (userRestaurantId == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "A felhasználóhoz étterem nem található.");
            }

            var restaurant = await restaurantRepository.GetRestaurantOrNull((int)userRestaurantId);
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
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "A felhasználóhoz étterem nem található.");
            }

            var restaurant = await restaurantRepository.EditRestaurant((int)ownerRestaurantId, editRestaurant);
            if (restaurant == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "Az étterem nem található.");
            }
            return restaurant;
        }
        public async Task ChangeMyRestaurantShowStatus(bool value)
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "A felhasználóhoz étterem nem található.");
            }

            try
            {
                using (var transaction = new TransactionScope(
                  TransactionScopeOption.Required,
                  new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                  TransactionScopeAsyncFlowOption.Enabled))
                {
                    await restaurantRepository.ChangeShowForUsersStatus((int)ownerRestaurantId, value);
                    await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, value);

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
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, "A felhasználóhoz étterem nem található.");
            }

            try
            {
                await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, value);
            }
            catch (ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
            }
        }
    }
}
