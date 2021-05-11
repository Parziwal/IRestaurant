using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// Az éttermekhez tartozó ételekkel kapcsolatos adatok lekéréséért kezeléséért felelős.
    /// </summary>
    public interface IFoodRepository
    {
        /// <summary>
        /// A megadott azonosítójú étel lekérdezése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étel adatai.</returns>
        Task<FoodDto> GetFood(int foodId);

        /// <summary>
        /// A megadott azonosítójú étteremhez tartozó ételek listájának lekérdezése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étteremhez tartozó ételek listája.</returns>
        Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId);

        /// <summary>
        /// Étel hozzáadása a megadott azonosítójú étteremhez.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="food">A hozzáadandó étel.</param>
        /// <returns>A hozzáadott étel adatai.</returns>
        Task<FoodDto> AddFoodToMenu(int restaurantId, CreateFoodDto food);

        /// <summary>
        /// A megadott azonosítójú étel törlése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        Task DeleteFoodFromMenu(int foodId);

        /// <summary>
        /// Kép hozzáadása a megadott azonosítójú ételhez.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        Task<string> UploadFoodImage(int foodId, UploadImageDto uploadedImage);

        /// <summary>
        /// A megadott azonosítójú étel képének törlése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        Task DeleteFoodImage(int foodId);

        /// <summary>
        /// A megadott azonosítójú étel szerkesztése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="food">A étel módosítandó adatai.</param>
        /// <returns>A módosított étel.</returns>
        Task<FoodDto> EditFood(int foodId, EditFoodDto food);

        /// <summary>
        /// Az étterem azonosítójának lekérdezése, amihez az étel tartozik.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étterem azonosítója.</returns>
        Task<int> GetFoodRestaurantId(int foodId);
    }
}
