using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO.Restaurants;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Images;

namespace IRestaurant.BL.Managers
{
    public class RestaurantManager
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IFoodRepository foodRepository;
        public RestaurantManager(IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IFoodRepository foodRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.foodRepository = foodRepository;
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviewList(string restaurantName = null)
        {
            return await restaurantRepository.GetRestaurantOverviewList(restaurantName);
        }

        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
               var restaurantDetails = await restaurantRepository.GetRestaurantDetails(restaurantId);
                restaurantDetails.IsCurrentGuestFavourite = await restaurantRepository.IsThisRestaurantGuestFavourite(restaurantId, userId);
                return restaurantDetails;
            }

            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetOwnerRestaurantId(userId) : -1;
            if (restaurantId == ownerRestaurantId)
            {
                return await restaurantRepository.GetRestaurantDetails(restaurantId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező étterem megtekintéséhez nincs jogosultságod.");
        }
        public async Task<RestaurantDetailsDto> GetMyRestaurantDetails()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await GetRestaurantDetails(ownerRestaurantId);
        }
        public async Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId)
        {
            return await restaurantRepository.CreateDefaultRestaurant(ownerId);
        }
        public async Task<RestaurantDetailsDto> EditMyRestaurant(EditRestaurantDto editRestaurant)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await restaurantRepository.EditRestaurant(ownerRestaurantId, editRestaurant);
        }

        public async Task<string> UploadMyRestaurantImage(UploadImageDto uploadedImage)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await restaurantRepository.UploadRestaurantImage(ownerRestaurantId, uploadedImage);
        }

        public async Task DeleteMyRestaurantImage()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            await restaurantRepository.DeleteRestaurantImage(ownerRestaurantId);
        }

        public async Task<RestaurantSettingsDto> GetMyRestaurantSettings()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await restaurantRepository.GetRestaurantSettings(ownerRestaurantId);
        }

        public async Task ShowMyRestaurantForUsers()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            await checkIfRestaurantDataNotEmpty(ownerRestaurantId);

            await restaurantRepository.ChangeShowForUsersStatus(ownerRestaurantId, true);
        }

        public async Task HideMyRestaurantForUsers()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            using (var transaction = new TransactionScope(
              TransactionScopeOption.Required,
              new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
              TransactionScopeAsyncFlowOption.Enabled))
            {
                await restaurantRepository.ChangeShowForUsersStatus(ownerRestaurantId, false);
                await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, false);

                transaction.Complete();
            }
        }

        public async Task TurnOnMyRestaurantOrderStatus()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            if (!await restaurantRepository.IsRestaurantAvailableForUsers(ownerRestaurantId))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A rendelési lehetőség engedélyezése nem lehetséges, amíg az étterem nem elérető.");
            }
            if ((await foodRepository.GetRestaurantMenu(ownerRestaurantId)).Count == 0)
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A rendelési lehetőség engedélyezése nem lehetséges, amíg az étlap üres.");
            }

            await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, true);
        }

        public async Task TurnOffMyRestaurantOrderStatus()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, false);
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurantList(string restaurantName = null)
        {
            string userId = userRepository.GetCurrentUserId();
            return await restaurantRepository.GetGuestFavouriteRestaurantList(userId, restaurantName);
        }

        public async Task AddRestaurantToUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.AddRestaurantToGuestFavourite(restaurantId, userId);
        }

        public async Task RemoveRestaurantFromUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.RemoveRestaurantFromGuestFavourite(restaurantId, userId);
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
                    "Az étterem elérhetővé tétele nem lehetséges, amíg a kötelező adatok nem kerülnek kitöltésre.");
            }
        }
    }
}
