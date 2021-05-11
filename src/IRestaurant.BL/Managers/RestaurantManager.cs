using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.DTO.Restaurants;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.Data;

namespace IRestaurant.BL.Managers
{
    /// <summary>
    /// Az éteremmel kapcsolatos adatok lekérdezésének, manipulációjának és a kedvenc éttermek
    /// kezelésének szabályozásáért felelős.
    /// </summary>
    public class RestaurantManager
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IFoodRepository foodRepository;

        /// <summary>
        /// A szükséges adatelérési rétegbeli függőségek elkérése.
        /// </summary>
        /// <param name="restaurantRepository">Az étteremeket kezeli.</param>
        /// <param name="userRepository">A felhasználók adatait kezeli.</param>
        /// <param name="foodRepository">Az ételeket kezeli.</param>
        public RestaurantManager(IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IFoodRepository foodRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.foodRepository = foodRepository;
        }

        /// <summary>
        /// A megadott névre illeszkedő éttermek listájának lekérése.
        /// </summary>
        /// <param name="restaurantName">Az keresett étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviewList(string restaurantName = null)
        {
            return await restaurantRepository.GetRestaurantOverviewList(restaurantName);
        }

        /// <summary>
        /// A megadott azonosítójú étterem részletes adatainak lekérdezése, ha az étterem publikusan elérhető,
        /// vagy az aktuális felhasználó az étterem tulajdonosa.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
               var restaurantDetails = await restaurantRepository.GetRestaurantDetails(restaurantId);
                restaurantDetails.IsCurrentGuestFavourite = await restaurantRepository.IsThisRestaurantGuestFavourite(restaurantId, userId);
                return restaurantDetails;
            }

            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;
            if (restaurantId == ownerRestaurantId)
            {
                return await restaurantRepository.GetRestaurantDetails(restaurantId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező étterem megtekintéséhez nincs jogosultságod.");
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem adatainak lekérdezése.
        /// </summary>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> GetMyRestaurantDetails()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await GetRestaurantDetails(ownerRestaurantId);
        }

        /// <summary>
        /// Étterem létrehozása alapméretezett adatokkal az aktuális felhasználóhoz,
        /// ha még nem létezik hozzá étterem és a felhasználó szerepköre étterem.
        /// </summary>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> CreateDefaultRestaurant()
        {
            string userId = userRepository.GetCurrentUserId();
            if (await userRepository.UserHasRestaurant(userId))
            {
                return await restaurantRepository.CreateDefaultRestaurant(userId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott felhasználóhoz már létezik étterem.");
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem adatainak szerkesztése.
        /// </summary>
        /// <param name="editRestaurant">Az étterem módosítandó adatai.</param>
        /// <returns>Az étterem módosított részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> EditMyRestaurant(EditRestaurantDto editRestaurant)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await restaurantRepository.EditRestaurant(ownerRestaurantId, editRestaurant);
        }

        /// <summary>
        /// Kép feltöltése az aktuális felhasználóhoz tartozó étteremhez.
        /// </summary>
        /// <param name="uploadedImage">A képet tartalmazó osztály.</param>
        /// <returns>A kép relatív elérési útvonala.</returns>
        public async Task<string> UploadMyRestaurantImage(UploadImageDto uploadedImage)
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await restaurantRepository.UploadRestaurantImage(ownerRestaurantId, uploadedImage);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem képének törlése.
        /// </summary>
        public async Task DeleteMyRestaurantImage()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            await restaurantRepository.DeleteRestaurantImage(ownerRestaurantId);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem beállítási adatainak lekérdezése.
        /// </summary>
        /// <returns>Az étterem beállításainak állapotai.</returns>
        public async Task<RestaurantSettingsDto> GetMyRestaurantSettings()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await restaurantRepository.GetRestaurantSettings(ownerRestaurantId);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem elérhetővé tétele a felhasználók számára,
        /// ha a kötelezően kitöltendő adatok meg vannak adva.
        /// </summary>
        public async Task ShowMyRestaurantForUsers()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);
            var restaurant = await restaurantRepository.GetRestaurantDetails(ownerRestaurantId);

            if (string.IsNullOrEmpty(restaurant.Name)
                || string.IsNullOrEmpty(restaurant.ShortDescription)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.City)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.Street)
                || string.IsNullOrEmpty(restaurant.RestaurantAddress.PhoneNumber))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "Az étterem elérhetővé tétele nem lehetséges, amíg a kötelező adatok nem kerülnek kitöltésre.");
            }

            await restaurantRepository.ChangeShowForUsersStatus(ownerRestaurantId, true);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem elrejtése, levétele a publikusan elérhető éttermek listájából,
        /// ezzel együtt a rendelési opció is kikapcsolásra kerül.
        /// </summary>
        public async Task HideMyRestaurantForUsers()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

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

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének bekapcsolása,
        /// ha az étterem elérhető és az étteremhez minimum egy étel tartozik.
        /// </summary>
        public async Task TurnOnMyRestaurantOrderStatus()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            if (!await restaurantRepository.IsRestaurantAvailableForUsers(ownerRestaurantId))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A rendelési lehetőség engedélyezése nem lehetséges, amíg az étterem nem elérető.");
            }

            int foodCount = (await foodRepository.GetRestaurantMenu(ownerRestaurantId)).Count;
            if (foodCount == 0)
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A rendelési lehetőség engedélyezése nem lehetséges, amíg az étlap üres.");
            }

            await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, true);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének kikapcsolása.
        /// </summary>
        public async Task TurnOffMyRestaurantOrderStatus()
        {
            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            await restaurantRepository.ChangeOrderAvailableStatus(ownerRestaurantId, false);
        }

        /// <summary>
        /// Az aktuális vendég kedvenc éttermeinek lekérdezése, ami a szűrési feltételként megadott névre illeszkedik.
        /// </summary>
        /// <param name="restaurantName">A keresett étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurantList(string restaurantName = null)
        {
            string userId = userRepository.GetCurrentUserId();
            return await restaurantRepository.GetGuestFavouriteRestaurantList(userId, restaurantName);
        }

        /// <summary>
        /// A megadott azonosítójú étterem felvétele az aktuális vendég kedvencei közé.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        public async Task AddRestaurantToUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.AddRestaurantToGuestFavourite(restaurantId, userId);
        }

        /// <summary>
        /// A megadott azonosítójú étterem eltávolítása törlése az aktuális vendég kedvencei közül.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        public async Task RemoveRestaurantFromUserFavourite(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            await restaurantRepository.RemoveRestaurantFromGuestFavourite(restaurantId, userId);
        }
    }
}
