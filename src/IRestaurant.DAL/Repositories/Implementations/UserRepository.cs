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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor accessor;

        public UserRepository(ApplicationDbContext dbContext, IHttpContextAccessor accessor)
        {
            this.dbContext = dbContext;
            this.accessor = accessor;
        }

        public async Task<AddressWithIdDto> GetUserAddress(int addressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                                        .SingleOrDefaultAsync(ua => ua.Id == addressId))
                                        .CheckIfUserAddressNull();

            return await dbContext.Entry(dbUserAddress).ToAddressWithIdDto();
        }

        public async Task<IReadOnlyCollection<AddressWithIdDto>> GetUserAddressList(string userId)
        {
            var dbUser = (await dbContext.Users
                                        .SingleOrDefaultAsync(u => u.Id == userId))
                                        .CheckIfUserNull();

            return await dbContext.UserAddresses
                        .Where(ua => ua.User == dbUser)
                        .ToAddressWithIdDtoList();
        }

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

        public async Task<string> GetUserAddressUserId(int addressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                                        .SingleOrDefaultAsync(ua => ua.Id == addressId))
                                        .CheckIfUserAddressNull();

            return dbUserAddress.UserId;
        }

        public async Task<int> GetUserRestaurantId(string userId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.OwnerId == userId))
                                    .CheckIfRestaurantNull();
            return dbRestaurant.Id;
        }

        public async Task<bool> UserHasRestaurant(string userId)
        {
            return await dbContext.Restaurants.SingleOrDefaultAsync(r => r.OwnerId == userId) != null;
        }

        public string GetCurrentUserId()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

    internal static class UserRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<AddressWithIdDto>> ToAddressWithIdDtoList(this IQueryable<UserAddress> addresses)
        {
            return await addresses.Select(a => new AddressWithIdDto(a)).ToListAsync();
        }

        public static async Task<AddressWithIdDto> ToAddressWithIdDto(this EntityEntry<UserAddress> address)
        {
            return new AddressWithIdDto(address.Entity);
        }

        public static ApplicationUser CheckIfUserNull(this ApplicationUser user,
            string errorMessage = "A felhasználó nem található.")
        {
            if (user == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return user;
        }

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
