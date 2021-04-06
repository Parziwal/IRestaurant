using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
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
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.OwnerId == userId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A felhasználóhoz étterem nem található.");
            }

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
}
