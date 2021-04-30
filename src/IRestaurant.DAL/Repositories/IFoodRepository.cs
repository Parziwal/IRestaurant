using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IFoodRepository
    {
        Task<FoodDto> GetFood(int foodId);
        Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId);
        Task<FoodDto> AddFoodToMenu(int restaurantId, CreateFoodDto food);
        Task<string> UploadFoodImage(int foodId, UploadImageDto uploadedImage);
        Task DeleteFoodImage(int foodId);
        Task DeleteFoodFromMenu(int foodId);
        Task<FoodDto> EditFood(int foodId, EditFoodDto food);
        Task<int> GetFoodRestaurantId(int foodId);
    }
}
