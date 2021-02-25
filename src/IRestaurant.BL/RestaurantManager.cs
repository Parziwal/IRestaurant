using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IRestaurant.BL
{
    public class RestaurantManager
    {
        private IRestaurantRepository restaurantRepository;
        private IUserRepository userRepository;

        public RestaurantManager(IRestaurantRepository restaurantRepository, IUserRepository userRepository)
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
        public async Task<RestaurantDto> GetOwnerRestaurantOrNull(string ownerId)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(ownerId);
            if (ownerRestaurantId == null)
            {
                return null;
            }
            return await restaurantRepository.GetRestaurantOrNull((int)ownerRestaurantId);
        }
        public async Task<RestaurantDto> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<RestaurantDto> EditRestaurant(string ownerId, EditRestaurantDto editRestaurant)
        {
            return await restaurantRepository.EditRestaurant(ownerId, editRestaurant);
        }
        public async Task ShowRestaurantForUsers(string ownerId)
        {
            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus(ownerId, true);
                await restaurantRepository.ChangeOrderAvailableStatus(ownerId, true);

                transaction.Complete();
            }
        }

        public async Task HideRestaurantFromUsers(string ownerId)
        {
            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus(ownerId, false);
                await restaurantRepository.ChangeOrderAvailableStatus(ownerId, false);

                transaction.Complete();
            }
        }

        public async Task TurnOnOrderOption(string ownerId)
        {
            await restaurantRepository.ChangeOrderAvailableStatus(ownerId, true);
        }

        public async Task TurnOffOrderOption(string ownerId)
        {
            await restaurantRepository.ChangeOrderAvailableStatus(ownerId, false);
        }
    }
}
