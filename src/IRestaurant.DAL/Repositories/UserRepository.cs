using IRestaurant.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
