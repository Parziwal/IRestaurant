using IRestaurant.DAL.DTO.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IFoodRepository
    {
        Task<FoodDto> GetFood(int foodId);
        Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId);
        Task<FoodDto> AddFoodToMenu(int restaurantId, CreateFoodDto food);
        Task DeleteFoodFromMenu(int foodId);
        Task<FoodDto> EditFood(int foodId, EditFoodDto food);
        Task<int> GetFoodRestaurantId(int foodId);
    }
}
