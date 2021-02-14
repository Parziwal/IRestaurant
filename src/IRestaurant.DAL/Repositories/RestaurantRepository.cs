using IRestaurant.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext dbContext;
        public RestaurantRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<DTO.RestaurantOverview>> ListRestaurantOverviews(string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants.GetRestaurantOverviews();
            }
            else
            {
                return await dbContext.Restaurants.Where(r => r.Name.Contains(restaurantName)).GetRestaurantOverviews();
            }
        }

        public async Task<DTO.Restaurant> GetRestaurantOrNull(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            return dbRestaurant?.GetRestaurant();
        }

        public async Task<DTO.Restaurant> InsertDeafaultRestaurant(string ownerId)
        {
            var dbRestaurant = new Models.Restaurant { OwnerId = ownerId };

            await dbContext.AddAsync(dbRestaurant);
            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }

        public async Task<DTO.Restaurant> EditRestaurant(int restaurantId, DTO.EditRestaurant editRestaurant)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                return null;
            }

            dbRestaurant.Name = editRestaurant.Name;
            dbRestaurant.ShortDescription = editRestaurant.ShortDescription;
            dbRestaurant.DetailedDescription = editRestaurant.DetailedDescription;
            dbRestaurant.ZipCode = editRestaurant.ZipCode;
            dbRestaurant.City = editRestaurant.City;
            dbRestaurant.Street = editRestaurant.Street;
            dbRestaurant.PhoneNumber = editRestaurant.PhoneNumber;
            //TODO: képfeltöltés

            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }

        public async Task<bool> ShowRestaurantForUsers(int restaurantId)
        {
            return await ChangeShowForUsersStatus(restaurantId, true);
        }

        public async Task<bool> HideRestaurantFromUsers(int restaurantId)
        {
            return await ChangeShowForUsersStatus(restaurantId, false);
        }

        private async Task<bool> ChangeShowForUsersStatus(int restaurantId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                return false;
            }

            if (value && string.IsNullOrEmpty(dbRestaurant.Name)
                && string.IsNullOrEmpty(dbRestaurant.ShortDescription)
                && string.IsNullOrEmpty(dbRestaurant.DetailedDescription)
                && string.IsNullOrEmpty(dbRestaurant.City)
                && string.IsNullOrEmpty(dbRestaurant.Street)
                && string.IsNullOrEmpty(dbRestaurant.PhoneNumber)
                && dbRestaurant.ZipCode != null
                )
            {
                throw new ArgumentException("A kötelező adatok megadása nélkül az étterem nem publikálható.");
            }

            dbRestaurant.ShowForUsers = value;
            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<DTO.Restaurant> TurnOnOrderOption(int restaurantId)
        {
            return await ChangeOrderAvailableStatus(restaurantId, true);
        }

        public async Task<DTO.Restaurant> TurnOffOrderOption(int restaurantId)
        {
            return await ChangeOrderAvailableStatus(restaurantId, false);
        }

        private async Task<DTO.Restaurant> ChangeOrderAvailableStatus(int restaurantId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                return null;
            }

            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }
    }

    internal static class RestaurantRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<DTO.RestaurantOverview>> GetRestaurantOverviews(this IQueryable<Models.Restaurant> restaurants)
        {
            return await restaurants.Select(r => new DTO.RestaurantOverview(r)).ToListAsync();
        }

        public static DTO.Restaurant GetRestaurant(this Models.Restaurant restaurant)
        {
            return new DTO.Restaurant(restaurant, restaurant.Owner);
        }
    }
}
