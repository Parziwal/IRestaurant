using Hellang.Middleware.ProblemDetails;
using IRestaurant.BL.Extensions;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.BL.Managers
{
    /// <summary>
    /// Az ételekkel kapcsolatos adatok lekérési és adatmanipulációs műveleteinek szabályzásáért felelős.
    /// </summary>
    public class FoodManager
    {
        private readonly IFoodRepository foodRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContext;

        /// <summary>
        /// A szükséges adatelérési rétegbeli függőségek elkérése.
        /// </summary>
        /// <param name="foodRepository">Az ételeket kezeli.</param>
        /// <param name="restaurantRepository">Az étteremeket kezeli.</param>
        /// <param name="userRepository">A felhasználók adatait kezeli.</param>
        /// <param name="httpContext">A HttpContext-hez biztosít hozzáférést.</param>
        public FoodManager(IFoodRepository foodRepository,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IHttpContextAccessor httpContext)
        {
            this.foodRepository = foodRepository;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.httpContext = httpContext;
        }

        /// <summary>
        /// A megadott azonosítóval rendelkező étel lekérése, ha az étterem, amihez az étel tartozik
        /// elérhető vagy maga az étterem tulajdonos kéri le az adatokat.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étel adatai.</returns>
        public async Task<FoodDto> GetFood(int foodId)
        {
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(foodRestaurantId))
            {
                return await foodRepository.GetFood(foodId);
            }

            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;

            if (foodRestaurantId == ownerRestaurantId)
            {
                return await foodRepository.GetFood(foodId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező étel megtekintéséhez nincs jogosultságod.");
        }

        /// <summary>
        /// Az étteremhez tartozó ételek listájának lekérése, ha az étterem, amihez az étel tartozik
        /// elérhető vagy maga az étterem tulajdonos kéri le az adatokat.
        /// </summary>
        /// <param name="restaurantId">AZ étterem azonosítója.</param>
        /// <returns>Az étterem ételeinek listája.</returns>
        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;

            if (restaurantId == ownerRestaurantId)
            {
                return await foodRepository.GetRestaurantMenu(restaurantId);
            }

            return new List<FoodDto>();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem ételeinek lekérése.
        /// </summary>
        /// <returns>Az aktuális felhasználó éttermének ételei.</returns>
        public async Task<IReadOnlyCollection<FoodDto>> GetMyRestaurantMenu()
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await GetRestaurantMenu(ownerRestaurantId);
        }

        /// <summary>
        /// A paraméterül kapott étel hozzáadása az aktuális felhasználó étterméhez.
        /// </summary>
        /// <param name="food">Az létrehozandó étel adatai.</param>
        /// <returns>A létrehozott étel adatai.</returns>
        public async Task<FoodDto> AddFoodToMenu(CreateFoodDto food)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await foodRepository.AddFoodToMenu(ownerRestaurantId, food);
        }

        /// <summary>
        /// Kép feltöltése a megadott azonosítóval rendelkező ételhez, ha az étel ugyanahhoz
        /// az étteremhez tartozik, mint amit az aktuális felhasználó birtokol.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="uploadedImage">A képet tartalmazó osztály.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        public async Task<string> UploadFoodImage(int foodId, UploadImageDto uploadedImage)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                return await foodRepository.UploadFoodImage(foodId, uploadedImage);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező étel képének megváltoztatásához nincs jogosultságod.");
        }

        /// <summary>
        /// A megadott azonosítóval rendelkező étel képének törlése, ha az étel ugyanahhoz
        /// az étteremhez tartozik, mint amit az aktuális felhasználó birtokol.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        public async Task DeleteFoodImage(int foodId)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                await foodRepository.DeleteFoodImage(foodId);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                   "A megadott azonosítóval rendelkező étel képének törléséhez nincs jogosultságod.");
        }

        /// <summary>
        /// A megadott azonosítójú étel törlése, ha az étel ugyanahhoz
        /// az étteremhez tartozik, mint amit az aktuális felhasználó birtokol.
        /// Ha az étteremhez tartozó utolsó étel is törlésre kerül, akkor a rendelési opció
        /// automatikusan kikapcsolásra kerül.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        public async Task DeleteFoodFromMenu(int foodId)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);
            int foodRestaurantId = await foodRepository.GetFoodRestaurantId(foodId);

            if (ownerRestaurantId == foodRestaurantId)
            {
                await foodRepository.DeleteFoodFromMenu(foodId);

                int foodCount = (await foodRepository.GetRestaurantMenu(ownerRestaurantId)).Count;
                if (foodCount == 0)
                {
                    await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, false);
                }

                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező étel törléséhez nincs jogosultságod.");
        }

        /// <summary>
        /// A megadott azonosítójú étel adatainak módosítása, ha az étel ugyanahhoz
        /// az étteremhez tartozik, mint amit az aktuális felhasználó birtokol.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="food">Az étel módosítandó adatai.</param>
        /// <returns></returns>
        public async Task<FoodDto> EditFood(int foodId, EditFoodDto food)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);
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
