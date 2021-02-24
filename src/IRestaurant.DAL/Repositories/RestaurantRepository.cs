using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO;
using IRestaurant.DAL.Models;
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

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants
                    .Include(r => r.Reviews)
                    .Where(r => r.ShowForUsers)
                    .GetRestaurantOverviews();
            }
            else
            {
                return await dbContext.Restaurants
                    .Include(r => r.Reviews)
                    .Where(r => r.Name.Contains(restaurantName) && r.ShowForUsers)
                    .GetRestaurantOverviews();
            }
        }

        public async Task<RestaurantDto> GetRestaurantOrNull(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants
                                    .Include(r => r.Owner)
                                    .Include(r => r.Reviews)
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId);

            return dbRestaurant?.GetRestaurant();
        }

        public async Task<RestaurantDto> CreateDefaultRestaurant(string ownerId)
        {
            var dbRestaurant = new Restaurant {
                Name = "",
                ShortDescription = "",
                DetailedDescription = "",
                Address = new Models.Address {
                    ZipCode = 1000,
                    City = "",
                    Street = "",
                    PhoneNumber = ""
                },
                ShowForUsers = false,
                IsOrderAvailable = false,
                OwnerId = ownerId
            };

            await dbContext.AddAsync(dbRestaurant);
            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }

        public async Task<RestaurantDto> EditRestaurant(string ownerId, EditRestaurantDto editRestaurant)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Owner.Id == ownerId);

            if (dbRestaurant == null)
            {
                return null;
            }

            dbRestaurant.Name = editRestaurant.Name;
            dbRestaurant.ShortDescription = editRestaurant.ShortDescription;
            dbRestaurant.DetailedDescription = editRestaurant.DetailedDescription;
            dbRestaurant.Address.ZipCode = editRestaurant.ZipCode;
            dbRestaurant.Address.City = editRestaurant.City;
            dbRestaurant.Address.Street = editRestaurant.Street;
            dbRestaurant.Address.PhoneNumber = editRestaurant.PhoneNumber;
            //TODO: képfeltöltés

            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }

        public async Task ChangeShowForUsersStatus(string ownerId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Owner.Id == ownerId);

            if (dbRestaurant == null)
            {
                throw new ArgumentException("A megadott felhasználó nem egy étterem tulajdonos.");
            }

            dbRestaurant.ShowForUsers = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeOrderAvailableStatus(string ownerId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Owner.Id == ownerId);

            if (dbRestaurant == null)
            {
                throw new ArgumentException("A megadott felhasználó nem egy étterem tulajdonos.");
            }

            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRestaurantAvailableForUsers(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                return false;
            }

            return dbRestaurant.ShowForUsers;
        }
    }

    internal static class RestaurantRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(this IQueryable<Restaurant> restaurants)
        {
            return await restaurants.Select(r => new RestaurantOverviewDto(r, CalculateRestaurantRating(r))).ToListAsync();
        }

        public static RestaurantDto GetRestaurant(this Restaurant restaurant)
        {
            return new RestaurantDto(restaurant, restaurant.Owner, CalculateRestaurantRating(restaurant));
        }

        private static double? CalculateRestaurantRating(Restaurant restaurant)
        {
            bool hasReview = restaurant.Reviews == null ? false : restaurant.Reviews.Any();
            if (!hasReview)
            {
                return null;
            }
            return restaurant.Reviews.Average(r => r.Rating);
        }
    }
}