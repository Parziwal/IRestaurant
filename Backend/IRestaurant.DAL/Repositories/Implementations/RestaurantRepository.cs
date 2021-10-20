using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Extensions;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        /// A megadott keresési feltételre illeszkedő éttermek áttekintő adatainak lekérése.
        /// </summary>
        /// <param name="search">Az étteremre vonatkozó keresési feltétel.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        public async Task<PagedListDto<RestaurantOverviewDto>> GetRestaurantOverviewList(RestaurantSearchDto search)
        {
            return await dbContext.Restaurants
                   .Where(r => r.ShowForUsers &&
                       (r.Name.Contains(search.NameOrShortDescriptionOrCity) || 
                       r.ShortDescription.Contains(search.NameOrShortDescriptionOrCity) || 
                       r.Address.City.Contains(search.NameOrShortDescriptionOrCity)))
                   .SortBy(search.SortBy)
                   .ToRestaurantOverviewDtoPagedList(search);
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

            string relativeImagePath = await imageRepository.UploadImage(uploadedImage.ImageFile, "restaurant");
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
        /// A megadott azonosítójú vendég kedvenc éttermeinek lekérdezése, ami a megadott keresési feltételre illeszkedik.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <param name="search">Az étteremre vonatkozó keresési feltétel.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        public async Task<PagedListDto<RestaurantOverviewDto>> GetGuestFavouriteRestaurantList(string guestId, RestaurantSearchDto search)
        {
            return await dbContext.Restaurants
                   .Where(r => r.ShowForUsers && r.UsersFavourite.Any(uf => uf.UserId == guestId) &&
                       (r.Name.Contains(search.NameOrShortDescriptionOrCity) ||
                       r.ShortDescription.Contains(search.NameOrShortDescriptionOrCity) ||
                       r.Address.City.Contains(search.NameOrShortDescriptionOrCity)))
                   .SortBy(search.SortBy)
                   .ToRestaurantOverviewDtoPagedList(search);
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
        /// Ha a felhasználó, vagy annak kedvencei között az megadott étterem nem található, akkor kivételt dobunk.
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
}