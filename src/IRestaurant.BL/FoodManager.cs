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
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            int? foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (foodRestaurantId != null
                && (ownerRestaurantId == foodRestaurantId
                || await restaurantRepository.IsRestaurantAvailableForUsers((int)foodRestaurantId)))
            {
                return await foodRepository.GetFood(foodId);
            }

            return null;
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            return new List<FoodDto>();
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetOwnerRestaurantMenu()
        {
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                return new List<FoodDto>();
            }

            return await foodRepository.GetRestaurantMenu((int)ownerRestaurantId);
        }

        public async Task<FoodDto> AddFoodToMenu(CreateFoodDto food)
        {
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (ownerRestaurantId == null)
            {
                return null;
            }

            return await foodRepository.AddFoodToMenu((int)ownerRestaurantId, food);
        }

        public async Task<FoodDto> DeleteFoodFromMenu(int foodId)
        {
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            int? foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == null || ownerRestaurantId != foodRestaurantId)
            {
                return null;
            }

            return await foodRepository.DeleteFoodFromMenu(foodId);
        }

        public async Task<FoodDto> EditFood(int foodId, EditFoodDto food)
        {
            string userId = userRepository.GetCurrentUserId();

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            int? foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == null || ownerRestaurantId != foodRestaurantId)
            {
                return null;
            }

            return await foodRepository.EditFood(foodId, food);
        }
    }
}
