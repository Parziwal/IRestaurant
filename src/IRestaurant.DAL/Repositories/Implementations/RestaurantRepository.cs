using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
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

        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants
                                    .Include(r => r.Owner)
                                    .Include(r => r.Reviews)
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            return dbRestaurant.GetRestaurant();
        }

        public async Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId)
        {
            var dbOwner = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == ownerId);
            if (dbOwner == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval felhasználó nem létezik.");
            }

            var dbRestaurant = new Restaurant {
                Name = "",
                ShortDescription = "",
                DetailedDescription = "",
                ImagePath = null,
                Address = new AddressOwned {
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

        public async Task<RestaurantDetailsDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant)
        {
            var dbRestaurant = await dbContext.Restaurants
                                    .Include(r => r.Owner)
                                    .Include(r => r.Reviews)
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            dbRestaurant.Name = editRestaurant.Name;
            dbRestaurant.ShortDescription = editRestaurant.ShortDescription;
            dbRestaurant.DetailedDescription = editRestaurant.DetailedDescription;
            dbRestaurant.Address.ZipCode = editRestaurant.Address.ZipCode;
            dbRestaurant.Address.City = editRestaurant.Address.City;
            dbRestaurant.Address.Street = editRestaurant.Address.Street;
            dbRestaurant.Address.PhoneNumber = editRestaurant.Address.PhoneNumber;
            //TODO: képfeltöltés

            await dbContext.SaveChangesAsync();

            return dbRestaurant.GetRestaurant();
        }
        public async Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            return new RestaurantSettingsDto(dbRestaurant);
        }

        public async Task ChangeShowForUsersStatus(int restaurantId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            dbRestaurant.ShowForUsers = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeOrderAvailableStatus(int restaurantId, bool value)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRestaurantAvailableForUsers(int restaurantId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            return dbRestaurant.ShowForUsers;
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurants(string userId, string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants
                       .Include(r => r.Reviews)
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == userId))
                       .GetRestaurantOverviews();
            }
            else
            {
                return await dbContext.Restaurants
                       .Include(r => r.Reviews)
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == userId) && r.Name.Contains(restaurantName))
                       .GetRestaurantOverviews();
            }
        }

        public async Task AddRestaurantToUserFavourite(int restaurantId, string userId)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);
            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            var dbUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (dbUser == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval felhasználó nem létezik.");
            }

            if (await dbContext.FavouriteRestaurants.AnyAsync(fr => fr.Restaurant == dbRestaurant && fr.User == dbUser))
            {
                throw new EntityAlreadyExistsException("Az étterem már hozzáadásra került a kedvencekhez.");
            }

            await dbContext.FavouriteRestaurants.AddAsync(
                new FavouriteRestaurant {
                    Restaurant = dbRestaurant,
                    User = dbUser
                });
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveRestaurantFromUserFavourite(int restaurantId, string userId)
        {
            var dbFavourite = await dbContext.FavouriteRestaurants.SingleOrDefaultAsync(fr => fr.RestaurantId == restaurantId && fr.UserId == userId);
            if (dbFavourite == null)
            {
                throw new EntityNotFoundException("A felhasználó kedvenc étteremei között a megadott azonosítóval étterem nem található.");
            }

            dbContext.FavouriteRestaurants.Remove(dbFavourite);
            await dbContext.SaveChangesAsync();
        }
    }

    internal static class RestaurantRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviews(this IQueryable<Restaurant> restaurants)
        {
            return await restaurants.Select(r => new RestaurantOverviewDto(r, CalculateRestaurantRating(r))).ToListAsync();
        }

        public static RestaurantDetailsDto GetRestaurant(this Restaurant restaurant)
        {
            return new RestaurantDetailsDto(restaurant, restaurant.Owner, CalculateRestaurantRating(restaurant));
        }

        private static double? CalculateRestaurantRating(Restaurant restaurant)
        {
            bool hasReview = restaurant.Reviews == null ? false : restaurant.Reviews.Any();
            if (!hasReview)
            {
                return null;
            }
            return Math.Round(restaurant.Reviews.Average(r => r.Rating), 2);
        }
    }
}