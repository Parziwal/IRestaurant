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

        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IReadOnlyCollection<RestaurantOverview>> ListRestaurantOverviews(string restaurantName = null)
        {
            return await restaurantRepository.ListRestaurantOverviews(restaurantName);
        }

        public async Task<Restaurant> GetRestaurantOrNull(string userId, int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId)
                || await restaurantRepository.UserOwnsThisRestaurant(userId, restaurantId))
            {
                return await restaurantRepository.GetRestaurantOrNull(restaurantId);
            }

            return null;
        }
        public async Task<Restaurant> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<Restaurant> EditRestaurant(string ownerId, EditRestaurant editRestaurant)
        {
            return await restaurantRepository.EditRestaurant(ownerId, editRestaurant);
        }
        public async Task<bool> ShowRestaurantForUsers(string ownerId)
        {
            bool showResult = await restaurantRepository.ChangeShowForUsersStatus(ownerId, true);
            if (!showResult)
            {
                return false;
            }
            bool orderResult = await restaurantRepository.ChangeOrderAvailableStatus(ownerId, true);
            if (!orderResult)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> HideRestaurantFromUsers(string ownerId)
        {
            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                bool showWasSuccessfull = await restaurantRepository.ChangeShowForUsersStatus(ownerId, false);
                if (!showWasSuccessfull)
                {
                    return false;
                }
                bool orderWasSuccessfull = await restaurantRepository.ChangeOrderAvailableStatus(ownerId, false);
                if (!orderWasSuccessfull)
                {
                    return false;
                }

                transaction.Complete();

                return true;
            }
        }

        public async Task<bool> TurnOnOrderOption(string ownerId)
        {
            return await restaurantRepository.ChangeOrderAvailableStatus(ownerId, true);
        }

        public async Task<bool> TurnOffOrderOption(string ownerId)
        {
            return await restaurantRepository.ChangeOrderAvailableStatus(ownerId, false);
        }
    }
}
