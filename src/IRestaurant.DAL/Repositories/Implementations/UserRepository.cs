using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public async Task<int> GetUserRestaurantId(string userId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.OwnerId == userId))
                                    .CheckIfRestaurantNull("A megadott azonosítóval felhasználó nem található.");

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
