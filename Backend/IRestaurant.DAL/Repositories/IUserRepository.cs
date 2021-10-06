using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.DTO.Restaurants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// A felhasználóhoz kapcsolódó adatok eléréséért és kezeléséért felelős.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// A megadott azonosítójú felhasználóhoz egy étterem létrehozása alap adatokkal.
        /// </summary>
        /// <param name="userId">A felhasználó/tulajdonos azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        Task<RestaurantDetailsDto> CreateDefaultRestaurantForUser(string userId);

        /// <summary>
        /// A megadott azonosítójú lakcím lekérdezése.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <returns>A cím adatai.</returns>
        Task<AddressWithIdDto> GetUserAddress(int addressId);

        /// <summary>
        /// A megadott felhasználóhoz tartozó lakcímek listának lekérdezése.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <returns>A felhasználóhoz tartozó címek listája.</returns>
        Task<IReadOnlyCollection<AddressWithIdDto>> GetUserAddressList(string userId);

        /// <summary>
        /// Lakcím felvétele a megadott azonosítójú felhasználóhoz.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <param name="address">A létrehozandó lakcím adatai.</param>
        /// <returns>A létrehozott cím adatai.</returns>
        Task<AddressWithIdDto> CreatetUserAddress(string userId, CreateOrEditAddressDto address);

        /// <summary>
        /// A megadott azonosítójú lakcím szerkesztése.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <param name="address">A lakcím módosítandó adatai.</param>
        /// <returns>A módosított cím adatai.</returns>
        Task<AddressWithIdDto> EditUserAddress(int addressId, CreateOrEditAddressDto address);

        /// <summary>
        /// A megadott azonosítójú lakcím törlése.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        Task DeleteUserAddress(int addressId);

        /// <summary>
        /// A megadott azonosítójú címhez tartozó felhasználó egyedi azonosítójának lekérdezése.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <returns>A felhasználó egyedi azonosítója.</returns>
        Task<string> GetUserAddressUserId(int addressId);

        /// <summary>
        /// A megadott azonosítójú felhasználóhoz tartozó étterem egyedi azonosítójának lekérdezése.
        /// </summary>
        /// <param name="ownerId">A tfelhasználó/tulajdonos egyedi azonosítója.</param>
        /// <returns>A tulajdonos étteremének azonosítója.</returns>
        Task<int> GetMyRestaurantId(string ownerId);

        /// <summary>
        /// Megnézi, hogy a megadott felhasználóhoz tartozik-e étterem.
        /// </summary>
        /// <param name="userId">A felhasználó egyedi azonosítója.</param>
        /// <returns>Tartozik-e étterem a felhasználóhoz.</returns>
        Task<bool> UserHasRestaurant(string userId);
    }
}
