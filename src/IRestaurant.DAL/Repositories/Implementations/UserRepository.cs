using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// A felhasználóhoz kapcsolódó adatok eléréséért és kezeléséért felelős.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor accessor;

        /// <summary>
        /// Az adatbázis és a HttpContext hozzáférés inicializációja a konstruktorban.
        /// </summary>
        /// <param name="dbContext">Az adatbázis.</param>
        /// <param name="accessor">Hozzáférést biztosít a HttpContext-hez.</param>
        public UserRepository(ApplicationDbContext dbContext, IHttpContextAccessor accessor)
        {
            this.dbContext = dbContext;
            this.accessor = accessor;
        }

        /// <summary>
        /// A megadott azonosítójú lakcím lekérdezése.
        /// Ha a megadott azonosítóval lakcím nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <returns>A cím adatai.</returns>
        public async Task<AddressWithIdDto> GetUserAddress(int addressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                                        .SingleOrDefaultAsync(ua => ua.Id == addressId))
                                        .CheckIfUserAddressNull();

            return await dbContext.Entry(dbUserAddress).ToAddressWithIdDto();
        }

        /// <summary>
        /// A megadott felhasználóhoz tartozó lakcímek listának lekérdezése.
        /// Ha a megadott felhasználó nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <returns>A felhasználóhoz tartozó címek listája.</returns>
        public async Task<IReadOnlyCollection<AddressWithIdDto>> GetUserAddressList(string userId)
        {
            var dbUser = (await dbContext.Users
                                        .SingleOrDefaultAsync(u => u.Id == userId))
                                        .CheckIfUserNull();

            return await dbContext.UserAddresses
                        .Where(ua => ua.User == dbUser)
                        .ToAddressWithIdDtoList();
        }

        /// <summary>
        /// Lakcím felvétele a megadott azonosítójú felhasználóhoz.
        /// Ha a megadott felhasználó nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <param name="address">A létrehozandó lakcím adatai.</param>
        /// <returns>A létrehozott cím adatai.</returns>
        public async Task<AddressWithIdDto> CreatetUserAddress(string userId, CreateOrEditAddressDto address)
        {
            var dbUser = (await dbContext.Users
                            .SingleOrDefaultAsync(u => u.Id == userId))
                            .CheckIfUserNull();

            var dbUserAddress = new UserAddress
            {
                Address = new AddressOwned
                {
                    ZipCode = address.ZipCode,
                    City = address.City,
                    Street = address.Street,
                    PhoneNumber = address.PhoneNumber
                },
                User = dbUser
            };

            await dbContext.UserAddresses.AddAsync(dbUserAddress);
            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbUserAddress).ToAddressWithIdDto();
        }

        /// <summary>
        /// A megadott azonosítójú lakcím szerkesztése.
        /// Ha a megadott lakcím nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <param name="address">A lakcím módosítandó adatai.</param>
        /// <returns>A módosított cím adatai.</returns>
        public async Task<AddressWithIdDto> EditUserAddress(int addressId, CreateOrEditAddressDto address)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                            .SingleOrDefaultAsync(ua => ua.Id == addressId))
                            .CheckIfUserAddressNull();

            dbUserAddress.Address.ZipCode = address.ZipCode;
            dbUserAddress.Address.City = address.City;
            dbUserAddress.Address.Street = address.Street;
            dbUserAddress.Address.PhoneNumber = address.PhoneNumber;

            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbUserAddress).ToAddressWithIdDto();
        }

        /// <summary>
        /// A megadott azonosítójú lakcím törlése.
        /// Ha a megadott lakcím nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        public async Task DeleteUserAddress(int addressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                            .SingleOrDefaultAsync(ua => ua.Id == addressId))
                            .CheckIfUserAddressNull();

            dbContext.Remove(dbUserAddress);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// A megadott azonosítójú címhez tartozó felhasználó egyedi azonosítójának lekérdezése.
        /// Ha a megadott lakcím nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="addressId">A cím azonosítója.</param>
        /// <returns>A felhasználó egyedi azonosítója.</returns>
        public async Task<string> GetUserAddressUserId(int addressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                                        .SingleOrDefaultAsync(ua => ua.Id == addressId))
                                        .CheckIfUserAddressNull();

            return dbUserAddress.UserId;
        }

        /// <summary>
        /// A megadott azonosítójú felhasználóhoz tartozó étterem egyedi azonosítójának lekérdezése.
        /// Ha a megadott lakcím nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="ownerId">A tfelhasználó/tulajdonos egyedi azonosítója.</param>
        /// <returns>A tulajdonos étteremének azonosítója.</returns>
        public async Task<int> GetOwnerRestaurantId(string userId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.OwnerId == userId))
                                    .CheckIfRestaurantNull();
            return dbRestaurant.Id;
        }

        /// <summary>
        /// Megnézi, hogy a megadott felhasználóhoz tartozik-e étterem.
        /// </summary>
        /// <param name="userId">A felhasználó egyedi azonosítója.</param>
        /// <returns>Tartozik-e étterem a felhasználóhoz.</returns>
        public async Task<bool> UserHasRestaurant(string userId)
        {
            return await dbContext.Restaurants.SingleOrDefaultAsync(r => r.OwnerId == userId) != null;
        }

        /// <summary>
        /// A jelenleg bejelentkezett felhasználó egyedi azonosítójának lekérdezése.
        /// </summary>
        /// <returns>Az aktuális felhasználó egyedi azonosítója.</returns>
        public string GetCurrentUserId()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                        accessor.HttpContext.User.FindFirstValue("sub");
        }
    }

    /// <summary>
    ///  Az felhasználóhoz kapcsolódó extension metódusok.
    /// </summary>
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
        /// így az egységes kezelés/használat érdekében ebben az esetben is meghagytam az async jelzőt.
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
