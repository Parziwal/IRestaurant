using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetRestaurantOverviewList(string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants
                    .Where(r => r.ShowForUsers)
                    .ToRestaurantOverviewDtoList();
            }
            else
            {
                return await dbContext.Restaurants
                    .Where(r => r.Name.Contains(restaurantName) && r.ShowForUsers)
                    .ToRestaurantOverviewDtoList();
            }
        }

        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
        }

        public async Task<RestaurantDetailsDto> CreateDefaultRestaurant(string ownerId)
        {
            var dbOwner = (await dbContext.Users
                                .SingleOrDefaultAsync(u => u.Id == ownerId))
                                .CheckIfUserNull();

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

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
        }

        public async Task<RestaurantDetailsDto> EditRestaurant(int restaurantId, EditRestaurantDto editRestaurant)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            dbRestaurant.Name = editRestaurant.Name;
            dbRestaurant.ShortDescription = editRestaurant.ShortDescription;
            dbRestaurant.DetailedDescription = editRestaurant.DetailedDescription;
            dbRestaurant.Address.ZipCode = editRestaurant.Address.ZipCode;
            dbRestaurant.Address.City = editRestaurant.Address.City;
            dbRestaurant.Address.Street = editRestaurant.Address.Street;
            dbRestaurant.Address.PhoneNumber = editRestaurant.Address.PhoneNumber;
            //TODO: képfeltöltés

            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
        }
        public async Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return new RestaurantSettingsDto(dbRestaurant);
        }

        public async Task ChangeShowForUsersStatus(int restaurantId, bool value)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            dbRestaurant.ShowForUsers = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeOrderAvailableStatus(int restaurantId, bool value)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRestaurantAvailableForUsers(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return dbRestaurant.ShowForUsers;
        }

        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetUserFavouriteRestaurantList(string userId, string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == userId))
                       .ToRestaurantOverviewDtoList();
            }
            else
            {
                return await dbContext.Restaurants
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == userId) && r.Name.Contains(restaurantName))
                       .ToRestaurantOverviewDtoList();
            }
        }

        public async Task AddRestaurantToUserFavourite(int restaurantId, string userId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();
            var dbUser = (await dbContext.Users
                        .SingleOrDefaultAsync(u => u.Id == userId))
                        .CheckIfUserNull();

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
            var dbFavourite = (await dbContext.FavouriteRestaurants
                .SingleOrDefaultAsync(fr => fr.RestaurantId == restaurantId && fr.UserId == userId))
                .CheckIfFavouriteRestaurantNull();

            dbContext.FavouriteRestaurants.Remove(dbFavourite);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsThisRestaurantGuestFavourite(int restaurantId, string guestId)
        {
            return await dbContext.FavouriteRestaurants
                .SingleOrDefaultAsync(fr => fr.RestaurantId == restaurantId && fr.UserId == guestId) != null;
        }
    }

    internal static class RestaurantRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<RestaurantOverviewDto>> ToRestaurantOverviewDtoList(this IQueryable<Restaurant> restaurants)
        {
            return await restaurants
                        .Include(r => r.Reviews)
                        .Select(r => new RestaurantOverviewDto(r)).ToListAsync();
        }

        public static async Task<RestaurantDetailsDto> ToRestaurantDetailsDto(this EntityEntry<Restaurant> restaurant)
        {
            await restaurant.Collection(r => r.Reviews).LoadAsync();
            await restaurant.Reference(r => r.Owner).LoadAsync();
            return new RestaurantDetailsDto(restaurant.Entity);
        }

        public static Restaurant CheckIfRestaurantNull(this Restaurant restaurant,
            string errorMessage = "Az étterem nem található.")
        {
            if (restaurant == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return restaurant;
        }

        public static FavouriteRestaurant CheckIfFavouriteRestaurantNull(this FavouriteRestaurant favouriteRestaurant, 
            string errorMessage = "A felhasználó kedvenc étterme nem található.")
        {
            if (favouriteRestaurant == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return favouriteRestaurant;
        }
    }
}