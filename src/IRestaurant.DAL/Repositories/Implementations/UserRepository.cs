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

        public async Task<int?> GetUserRestaurantIdOrNull(string userId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.OwnerId == userId);

            if (dbRestaurant == null)
            {
                return null;
            }

            return dbRestaurant.Id;
        }

        public string GetCurrentUserId()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
