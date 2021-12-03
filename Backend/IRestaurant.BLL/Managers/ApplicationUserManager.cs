using IRestaurant.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.BLL.Extensions;

namespace IRestaurant.BLL.Managers
{
    /// <summary>
    /// A felhasználói adatok lekérdezését és kezelését végző műveletek szabályzásáért felelős.
    /// </summary>
    public class ApplicationUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContext;

        public ApplicationUserManager(IUserRepository userRepository,
                          IHttpContextAccessor httpContext)
        {
            this.userRepository = userRepository;
            this.httpContext = httpContext;
        }

        /// <summary>
        /// Étterem létrehozása alapméretezett adatokkal a megadott azonosítójú felhasználóhoz,
        /// ha még nem létezik hozzá étterem.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> CreateDefaultRestaurantForUser(string userId)
        {
            if (!(await userRepository.UserHasRestaurant(userId)))
            {
                return await userRepository.CreateDefaultRestaurantForUser(userId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott felhasználóhoz már létezik étterem.");
        }

        /// <summary>
        /// A megadott azonosítójú lakcím lekérdezése, ha a lakcím az aktuális felhasználójoz tartozik.
        /// </summary>
        /// <param name="addressId">A lakcím azonosítója.</param>
        /// <returns>A lakcím adatai.</returns>
        public async Task<AddressWithIdDto> GetUserAddress(int addressId)
        {
            string userId = httpContext.GetCurrentUserId();
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
            string userId = httpContext.GetCurrentUserId();
            return await userRepository.GetUserAddressList(userId);
        }

        /// <summary>
        /// Lakcím létrehozása az aktuális felhasználóhoz.
        /// </summary>
        /// <param name="address">A létrehozandó lakcím adatai.</param>
        /// <returns>A létrehozott lakcím.</returns>
        public async Task<AddressWithIdDto> CreateUserAddress(CreateOrEditAddressDto address)
        {
            string userId = httpContext.GetCurrentUserId();
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
            string userId = httpContext.GetCurrentUserId();
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
            string userId = httpContext.GetCurrentUserId();
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
