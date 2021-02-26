using IRestaurant.DAL.DTO.Food;
using IRestaurant.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<FoodDto> GetFood(string userId, int foodId)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId 
                || await restaurantRepository.IsRestaurantAvailableForUsers(foodRestaurantId))
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

        public async Task<IReadOnlyCollection<FoodDto>> GetOwnerRestaurantMenu(string ownerId)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(ownerId);

            if (ownerRestaurantId == null)
            {
                return new List<FoodDto>();
            }

            return await foodRepository.GetRestaurantMenu((int)ownerRestaurantId);
        }

        public async Task<FoodDto> AddFoodToMenu(string ownerId, CreateFoodDto food)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(ownerId);

            if (ownerRestaurantId == null)
            {
                return null;
            }

            return await foodRepository.AddFoodToMenu((int)ownerRestaurantId, food);
        }

        public async Task<FoodDto> DeleteFoodFromMenu(string ownerId, int foodId)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(ownerId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == null || ownerRestaurantId != foodRestaurantId)
            {
                return null;
            }

            return await foodRepository.DeleteFoodFromMenu(foodId);
        }

        public async Task<FoodDto> EditFood(string ownerId, int foodId, EditFoodDto food)
        {
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(ownerId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == null || ownerRestaurantId != foodRestaurantId)
            {
                return null;
            }

            return await foodRepository.EditFood(foodId, food);
        }
    }
}
