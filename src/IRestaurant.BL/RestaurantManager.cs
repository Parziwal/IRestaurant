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

        public async Task<RestaurantDto> GetRestaurantOrNull(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await restaurantRepository.GetRestaurantOrNull(restaurantId);
            }
            return null;
        }
        public async Task<RestaurantDto> GetOwnerRestaurantOrNull()
        {
            string userId = userRepository.GetCurrentUserId();
            int? userRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            if (userRestaurantId == null)
            {
                return null;
            }
            return await restaurantRepository.GetRestaurantOrNull((int)userRestaurantId);
        }
        public async Task<RestaurantDto> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<RestaurantDto> EditRestaurant(EditRestaurantDto editRestaurant)
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                return null;
            }

            return await restaurantRepository.EditRestaurant((int)ownerRestaurantId, editRestaurant);
        }
        public async Task ShowRestaurantForUsers()
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ArgumentException("A jelenlegi felhasználó nem egy étterem tulajdonos.");
            }

            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus((int)ownerRestaurantId, true);
                await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, true);

                transaction.Complete();
            }
        }

        public async Task HideRestaurantFromUsers()
        {
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ArgumentException("A jelenlegi felhasználó nem egy étterem tulajdonos.");
            }

            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus((int)ownerRestaurantId, false);
                await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, false);

                transaction.Complete();
            }
        }

        public async Task TurnOnOrderOption()
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ArgumentException("A jelenlegi felhasználó nem egy étterem tulajdonos.");
            }

            await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, true);
        }

        public async Task TurnOffOrderOption()
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                throw new ArgumentException("A jelenlegi felhasználó nem egy étterem tulajdonos.");
            }

            await restaurantRepository.ChangeOrderAvailableStatus((int)ownerRestaurantId, false);
        }
    }
}
