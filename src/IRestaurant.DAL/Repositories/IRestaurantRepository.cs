using System.Collections.Generic;
using System.Threading.Tasks;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.DTO.Restaurants;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// Az éttermek adatainak lekérdezéséért és manipulációjáért felelős.
    /// </summary>
    public interface IRestaurantRepository
    {
        /// <summary>
        /// A megadott névre illeszkedő éttermek listájának lekérése.
        /// </summary>
        /// <param name="restaurantName">Az keresett étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviewList(string restaurantName = null);

        /// <summary>
        /// Az étterem részletes adatainak lekérdezése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId);

        /// <summary>
        /// A megadott azonosítójú felhasználóhoz egy étterem létrehozása alap adatokkal.
        /// </summary>
        /// <param name="ownerId">A felhasználó/tulajdonos azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId);

        /// <summary>
        /// A megadott azonosítójú étterem adatainak módosítása.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="editRestaurant">Az étterem módosítandó adatai.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        Task<RestaurantDetailsDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant);

        /// <summary>
        /// Kép hozzáadása a megadott azonosítójú étteremhez.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        Task<string> UploadRestaurantImage(int restaurantId, UploadImageDto uploadedImage);

        /// <summary>
        /// A megadott azonosítójú étterem képének törlése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        Task DeleteRestaurantImage(int restaurantId);

        /// <summary>
        /// Az étterem beállításainak lekérdezése (mint elérhetőség és rendelési opció).
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem beállításainak állapotai.</returns>
        Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId);

        /// <summary>
        /// Az étterem elérhetőségi állapotának módosítása.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="value">Beállítandó elérhetőségi állapot.</param>
        Task ChangeShowForUsersStatus(int restaurantId, bool value);

        /// <summary>
        /// Az étteremtől való rendelési lehetőség módosítása.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="value">Beállítandó rendelési állapot.</param>
        Task ChangeOrderAvailableStatus(int restaurantId, bool value);

        /// <summary>
        /// Visszaadja, hogy az étterem elérhető-e a felhasználóknak vagy sem.
        /// </summary>
        /// <param name="restaurantId">Az étterem egyedi azonosítója.</param>
        /// <returns>Az étterem elérhetőségi állapota.</returns>
        Task<bool> IsRestaurantAvailableForUsers(int restaurantId);

        /// <summary>
        /// A megadott azonosítójú vendég kedvenc éttermeinek lekérdezése, ami a szűrési feltételként megadott névre illeszkedik.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <param name="restaurantName">Az ééterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        Task<IReadOnlyCollection<RestaurantOverviewDto>> GetGuestFavouriteRestaurantList(string guestId, string restaurantName = null);

        /// <summary>
        /// A megadott azonosítójú étterem felvétele a vendég kedvencei közé.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        Task AddRestaurantToGuestFavourite(int restaurantId, string guestId);

        /// <summary>
        /// A megadott azonosítójú étterem eltávolítása törlése a vendég kedvencei közül.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        Task RemoveRestaurantFromGuestFavourite(int restaurantId, string guestId);

        /// <summary>
        /// Visszaadja, hogy a megadott azonosítójú étterem a vendég kedvence-e.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <returns>A vendég kedvence-e az étterem.</returns>
        Task<bool> IsThisRestaurantGuestFavourite(int restaurantId, string guestId);
    }
}
