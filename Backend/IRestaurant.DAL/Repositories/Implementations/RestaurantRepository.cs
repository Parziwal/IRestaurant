using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// Az éttermek adatainak lekérdezéséért és manipulációjáért felelős.
    /// </summary>
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageRepository imageRepository;

        /// <summary>
        /// Az adatbázis és a képkezelési repository inicializációja a konstruktorban.
        /// </summary>
        /// <param name="dbContext">Az adatbázis.</param>
        /// <param name="imageRepository">A képkezelési repository.</param>
        public RestaurantRepository(ApplicationDbContext dbContext, IImageRepository imageRepository)
        {
            this.dbContext = dbContext;
            this.imageRepository = imageRepository;
        }

        /// <summary>
        /// A megadott névre illeszkedő éttermek áttekintő adatainak lekérése.
        /// Ha a név paraméter null, akkor az összes elérhető éttermet visszaadjuk.
        /// </summary>
        /// <param name="restaurantName">Az étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
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

        /// <summary>
        /// Az étterem részletes adatainak lekérdezése.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        public async Task<RestaurantDetailsDto> GetRestaurantDetails(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
        }

        /// <summary>
        /// A megadott azonosítójú felhasználóhoz egy étterem létrehozása alap adatokkal.
        /// Ha a megadott azonosítóval felhasználó nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="ownerId">A felhasználó/tulajdonos azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
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

        /// <summary>
        /// A megadott azonosítójú étterem adatainak módosítása.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="editRestaurant">Az étterem módosítandó adatai.</param>
        /// <returns>Az étterem részletes adatai.</returns>
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

            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbRestaurant).ToRestaurantDetailsDto();
        }

        /// <summary>
        /// Kép hozzáadása a megadott azonosítójú étteremhez.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk,
        /// egyébként feltöltjük a képet és beállítjuk rá az étterem relatív elérési útját.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        public async Task<string> UploadRestaurantImage(int restaurantId, UploadImageDto uploadedImage)
        {
            var dbRestaurant = (await dbContext.Restaurants
                        .SingleOrDefaultAsync(r => r.Id == restaurantId))
                        .CheckIfRestaurantNull();

            string relativeImagePath = await imageRepository.UploadImage(uploadedImage.ImageFile, "Restaurant");
            imageRepository.DeleteImage(dbRestaurant.ImagePath);
            dbRestaurant.ImagePath = relativeImagePath;

            await dbContext.SaveChangesAsync();

            return relativeImagePath;
        }

        /// <summary>
        /// A megadott azonosítójú étterem képének törlése.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        public async Task DeleteRestaurantImage(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                        .SingleOrDefaultAsync(r => r.Id == restaurantId))
                        .CheckIfRestaurantNull();

            imageRepository.DeleteImage(dbRestaurant.ImagePath);
            dbRestaurant.ImagePath = null;

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Az étterem beállításainak lekérdezése (mint elérhetőség és rendelési opció).
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem beállításainak állapotai.</returns>
        public async Task<RestaurantSettingsDto> GetRestaurantSettings(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return new RestaurantSettingsDto(dbRestaurant);
        }

        /// <summary>
        /// Az étterem elérhetőségi állapotának módosítása.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="value">Beállítandó elérhetőségi állapot.</param>
        public async Task ChangeShowForUsersStatus(int restaurantId, bool value)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            dbRestaurant.ShowForUsers = value;
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Az étteremtől való rendelési lehetőség módosítása.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="value">Beállítandó rendelési állapot.</param>
        public async Task ChangeOrderAvailableStatus(int restaurantId, bool value)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            dbRestaurant.IsOrderAvailable = value;
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Visszaadja, hogy az étterem elérhető-e a felhasználóknak vagy sem.
        /// Ha a megadott azonosítóval étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem egyedi azonosítója.</param>
        /// <returns>Az étterem elérhetőségi állapota.</returns>
        public async Task<bool> IsRestaurantAvailableForUsers(int restaurantId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            return dbRestaurant.ShowForUsers;
        }

        /// <summary>
        /// A megadott azonosítójú vendég kedvenc éttermeinek lekérdezése, ami a szűrési feltételként megadott névre illeszkedik.
        /// Ha a név paraméter null, akkor az összes elérhető éttermet visszaadjuk.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <param name="restaurantName">Az ééterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        public async Task<IReadOnlyCollection<RestaurantOverviewDto>> GetGuestFavouriteRestaurantList(string guestId, string restaurantName = null)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return await dbContext.Restaurants
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == guestId))
                       .ToRestaurantOverviewDtoList();
            }
            else
            {
                return await dbContext.Restaurants
                       .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == guestId) && r.Name.Contains(restaurantName))
                       .ToRestaurantOverviewDtoList();
            }
        }

        /// <summary>
        /// A megadott azonosítójú étterem felvétele a vendég kedvencei közé.
        /// Ha a megadott azonosítóval étterem vagy vendég nem található, vagy az étterem már felvételre került,
        /// akkor ezt kivételel jelezzük.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        public async Task AddRestaurantToGuestFavourite(int restaurantId, string guestId)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();
            var dbUser = (await dbContext.Users
                        .SingleOrDefaultAsync(u => u.Id == guestId))
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

        /// <summary>
        /// A megadott azonosítójú étterem eltávolítása törlése a vendég kedvencei közül.
        /// Ha a felhasználó kedvencei között az megadott étterem nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        public async Task RemoveRestaurantFromGuestFavourite(int restaurantId, string guestId)
        {
            var dbFavourite = (await dbContext.FavouriteRestaurants
                .SingleOrDefaultAsync(fr => fr.RestaurantId == restaurantId && fr.UserId == guestId))
                .CheckIfFavouriteRestaurantNull();

            dbContext.FavouriteRestaurants.Remove(dbFavourite);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Visszaadja, hogy a megadott azonosítójú étterem a vendég kedvence-e.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <returns>A vendég kedvence-e az étterem.</returns>
        public async Task<bool> IsThisRestaurantGuestFavourite(int restaurantId, string guestId)
        {
            return await dbContext.FavouriteRestaurants
                .SingleOrDefaultAsync(fr => fr.RestaurantId == restaurantId && fr.UserId == guestId) != null;
        }
    }

    /// <summary>
    /// Az rendeléshez kapcsolódó extension metódusok.
    /// </summary>
    internal static class RestaurantRepositoryExtensions
    {
        /// <summary>
        /// A étterem típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="restaurants">Étterem típusú lekérdezés.</param>
        /// <returns>Áttekintő étterem adatokat tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<RestaurantOverviewDto>> ToRestaurantOverviewDtoList(this IQueryable<Restaurant> restaurants)
        {
            return await restaurants
                        .Include(r => r.Reviews)
                        .Select(r => new RestaurantOverviewDto(r)).ToListAsync();
        }

        /// <summary>
        /// Az étterem modell osztály átalakítása részletes adatokat tartalmazó adatátviteli objektummá.
        /// </summary>
        /// <param name="restaurant">Étterem típusú entitás.</param>
        /// <returns>Az étterem részletes adatait tartalmazó adatátviteli objektum.</returns>
        public static async Task<RestaurantDetailsDto> ToRestaurantDetailsDto(this EntityEntry<Restaurant> restaurant)
        {
            await restaurant.Collection(r => r.Reviews).LoadAsync();
            await restaurant.Reference(r => r.Owner).LoadAsync();
            return new RestaurantDetailsDto(restaurant.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott étterem típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="restaurant">Étterem típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Étterem típusú modell osztály.</returns>
        public static Restaurant CheckIfRestaurantNull(this Restaurant restaurant,
            string errorMessage = "Az étterem nem található.")
        {
            if (restaurant == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return restaurant;
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott kedvenc éttermet tartalamzó modell osztáy null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="favouriteRestaurant">A vendég egyik kedvenc éttermét tartalmazó modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>A vendég egyik kedvenc éttermét tartalmazó modell osztály.</returns>
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