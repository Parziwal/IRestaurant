using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Extensions
{
    internal static class UserRepositoryExtensions
    {
        /// <summary>
        /// A lakcím típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="addresses">Cím típusú lekérdezés.</param>
        /// <returns>A lakcímek adatait tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<AddressWithIdDto>> ToAddressWithIdDtoList(this IQueryable<UserAddress> addresses)
        {
            return await addresses.Select(a => new AddressWithIdDto(a)).ToListAsync();
        }

        /// <summary>
        /// Az lakcím modell osztály átalakítása adatátviteli objektummá.
        /// A metódus nem tartalmaz await operátort, így nem kéne async-nek lenni,
        /// de mivel a többi hasonló extension metódus (pl.: ToRestaurantDetialsDto()) tartalmaz ilyet,
        /// így az egységes kezelés érdekében ebben az esetben is meghagytam az async jelzőt.
        /// </summary>
        /// <param name="address">Cím típusú entitiás.</param>
        /// <returns>A lakcím adatait tartalmazó adatátviteli objektum.</returns>
#pragma warning disable CS1998
        public static async Task<AddressWithIdDto> ToAddressWithIdDto(this EntityEntry<UserAddress> address)
#pragma warning restore CS1998
        {
            return new AddressWithIdDto(address.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott felhasználó típusú modell osztáy null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="user">Felhasználó típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Felhasználó típusú modell osztály.</returns>
        public static ApplicationUser CheckIfUserNull(this ApplicationUser user,
            string errorMessage = "A felhasználó nem található.")
        {
            if (user == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return user;
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott lakcím típusú modell osztáy null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="userAddress">Lakcím típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Lakcím típusú modell osztály.</returns>
        public static UserAddress CheckIfUserAddressNull(this UserAddress userAddress,
            string errorMessage = "A felhasználó lakcíme nem található.")
        {
            if (userAddress == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return userAddress;
        }
    }
}
