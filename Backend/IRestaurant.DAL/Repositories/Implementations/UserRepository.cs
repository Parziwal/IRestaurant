using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Extensions;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// A megadott azonosítójú felhasználóhoz egy étterem létrehozása alap adatokkal.
        /// Ha a megadott azonosítóval felhasználó nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="userId">A felhasználó/tulajdonos azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> CreateDefaultRestaurantForUser(string userId)
        {
            var dbOwner = (await dbContext.Users
                                .SingleOrDefaultAsync(u => u.Id == userId))
                                .CheckIfUserNull();

            var dbRestaurant = new Restaurant
            {
                Name = "",
                ShortDescription = "",
                DetailedDescription = "",
                ImagePath = null,
                Address = new AddressOwned
                {
                    ZipCode = 1000,
                    City = "",
                    Street = "",
                    PhoneNumber = ""
                },
                ShowForUsers = false,
                IsOrderAvailable = false,
                OwnerId = userId
            };

            await dbContext.AddAsync(dbRestaurant);
            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
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
        public async Task<int> GetMyRestaurantId(string userId)
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
    }
}
