using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BL
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
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetUserRestaurantId(userId) : -1;

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
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetUserRestaurantId(userId) : -1;

            if (restaurantId == ownerRestaurantId)
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            return new List<FoodDto>();
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetOwnerRestaurantMenu()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetUserRestaurantId(userId);

            return await GetRestaurantMenu(ownerRestaurantId);
        }

        public async Task<FoodDto> AddFoodToMenu(CreateFoodDto food)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetUserRestaurantId(userId);

            return await foodRepository.AddFoodToMenu(ownerRestaurantId, food);
        }

        public async Task DeleteFoodFromMenu(int foodId)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetUserRestaurantId(userId);
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
            int ownerRestaurantId = await userRepository.GetUserRestaurantId(userId);
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
