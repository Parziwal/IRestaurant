using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.BL.Managers
{
    public class FoodManager
    {
        private readonly IFoodRepository foodRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        public FoodManager(IFoodRepository foodRepository,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository)
        {
            this.foodRepository = foodRepository;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
        }

        public async Task<FoodDto> GetFood(int foodId)
        {
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(foodRestaurantId))
            {
                return await foodRepository.GetFood(foodId);
            }

            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetOwnerRestaurantId(userId) : -1;

            if (foodRestaurantId == ownerRestaurantId)
            {
                return await foodRepository.GetFood(foodId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező étel megtekintéséhez nincs jogosultságod.");
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetOwnerRestaurantId(userId) : -1;

            if (restaurantId == ownerRestaurantId)
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            return new List<FoodDto>();
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetOwnerRestaurantMenu()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await GetRestaurantMenu(ownerRestaurantId);
        }

        public async Task<FoodDto> AddFoodToMenu(CreateFoodDto food)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);

            return await foodRepository.AddFoodToMenu(ownerRestaurantId, food);
        }

        public async Task<string> UploadFoodImage(int foodId, UploadImageDto uploadedImage)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                return await foodRepository.UploadFoodImage(foodId, uploadedImage);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező étel képének megváltoztatásához nincs jogosultságod.");
        }

        public async Task DeleteFoodImage(int foodId)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                await foodRepository.DeleteFoodImage(foodId);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                   "A megadott azonosítóval rendelkező étel képének törléséhez nincs jogosultságod.");
        }

        public async Task DeleteFoodFromMenu(int foodId)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                await foodRepository.DeleteFoodFromMenu(foodId);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező étel törléséhez nincs jogosultságod.");
        }

        public async Task<FoodDto> EditFood(int foodId, EditFoodDto food)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetOwnerRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                return await foodRepository.EditFood(foodId, food);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező étel szerkesztéséhez nincs jogosultságod.");
        }
    }
}
