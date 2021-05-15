using IRestaurant.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using IRestaurant.DAL.DTO.Addresses;

namespace IRestaurant.BL.Managers
{
    /// <summary>
    /// A felhasználói lakcímek lekérdezését és kezelését végző műveletek szabályzásáért felelős.
    /// </summary>
    public class UserAddressManager
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// A szükséges adatelérési rétegbeli függőségek elkérése.
        /// </summary>
        /// <param name="userRepository">A felhasználók adatait kezeli.</param>
        public UserAddressManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// A megadott azonosítójú lakcím lekérdezése, ha a lakcím az aktuális felhasználójoz tartozik.
        /// </summary>
        /// <param name="addressId">A lakcím azonosítója.</param>
        /// <returns>A lakcím adatai.</returns>
        public async Task<AddressWithIdDto> GetUserAddress(int addressId)
        {
            string userId = userRepository.GetCurrentUserId();
            string addressUserId = await userRepository.GetUserAddressUserId(addressId);

            if (userId == addressUserId)
            {
                return await userRepository.GetUserAddress(addressId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
               "A megadott azonosítóval rendelkező lakcím megtekintéséhez nincs jogosultságod.");
        }

        /// <summary>
        /// Az aktuális vendég összes lakcímének lekérdezése.
        /// </summary>
        /// <returns>Az aktuális vendég lakcímeinek listája.</returns>
        public async Task<IReadOnlyCollection<AddressWithIdDto>> GetCurrentGuestAddressList()
        {
            string userId = userRepository.GetCurrentUserId();
            return await userRepository.GetUserAddressList(userId);
        }

        /// <summary>
        /// Lakcím létrehozása az aktuális felhasználóhoz.
        /// </summary>
        /// <param name="address">A létrehozandó lakcím adatai.</param>
        /// <returns>A létrehozott lakcím.</returns>
        public async Task<AddressWithIdDto> CreateUserAddress(CreateOrEditAddressDto address)
        {
            string userId = userRepository.GetCurrentUserId();
            return await userRepository.CreatetUserAddress(userId, address);
        }

        /// <summary>
        /// A megadott azonosítójú lakcím szerkesztése, ha a lakcím az aktuális felhasználójoz tartozik.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <param name="address">A lakcím módosítandó adatai.</param>
        /// <returns>A módosított cím adatai.</returns>
        public async Task<AddressWithIdDto> EditUserAddress(int addressId, CreateOrEditAddressDto address)
        {
            string userId = userRepository.GetCurrentUserId();
            string addressUserId = await userRepository.GetUserAddressUserId(addressId);

            if (userId == addressUserId)
            {
                return await userRepository.EditUserAddress(addressId, address);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
               "A megadott azonosítóval rendelkező lakcím szerkesztéséhez nincs jogosultságod.");
        }

        /// <summary>
        /// A megadott azonosítójú lakcím törlése, ha a lakcím az aktuális felhasználójoz tartozik.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        public async Task DeleteUserAddress(int addressId)
        {
            string userId = userRepository.GetCurrentUserId();
            string addressUserId = await userRepository.GetUserAddressUserId(addressId);

            if (userId == addressUserId)
            {
                await userRepository.DeleteUserAddress(addressId);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
               "A megadott azonosítóval rendelkező lakcím szerkesztéséhez nincs jogosultságod.");
        }
    }
}
