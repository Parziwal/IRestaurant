using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// Az éttermekhez tartozó ételekkel kapcsolatos adatok lekéréséért kezeléséért felelős.
    /// </summary>
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageRepository imageRepository;

        /// <summary>
        /// Az adatbázis és a képkezelési repository inicializációja a konstruktorban.
        /// </summary>
        /// <param name="dbContext">Az adatbázis.</param>
        /// <param name="imageRepository">A képkezelési repository.</param>
        public FoodRepository(ApplicationDbContext dbContext, IImageRepository imageRepository)
        {
            this.dbContext = dbContext;
            this.imageRepository = imageRepository;
        }

        /// <summary>
        /// A megadott azonosítójú étel lekérdezése.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étel adatai.</returns>
        public async Task<FoodDto> GetFood(int foodId)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            return await dbContext.Entry(dbFood).ToFoodDto();
        }

        /// <summary>
        /// A megadott azonosítójú étteremhez tartozó ételek listájának lekérdezése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étteremhez tartozó ételek listája.</returns>
        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await dbContext.Foods
                        .Where(f => f.RestaurantId == restaurantId)
                        .ToFoodDtoList();
        }

        /// <summary>
        /// Étel hozzáadása a megadott azonosítójú étteremhez.
        /// Ha a megadott étterem nem létezik, akkor azt kivételel jelezük.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="food">A hozzáadandó étel.</param>
        /// <returns>A hozzáadott étel adatai.</returns>
        public async Task<FoodDto> AddFoodToMenu(int restaurantId, CreateFoodDto food)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            var dbFood = new Food {
                Name = food.Name,
                Price = food.Price,
                Description = food.Description,
                RestaurantId = restaurantId
            };

            await dbContext.Foods.AddAsync(dbFood);
            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbFood).ToFoodDto();
        }

        /// <summary>
        /// A megadott azonosítójú étel törlése.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk.
        /// Ha az ételre van már hivatkozés, azaz rendelés, akkor csak "soft delete"-et,
        /// egyébként pedig "hard delete"-et hajtunk végre.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        public async Task DeleteFoodFromMenu(int foodId)
        {
            var dbFood = (await dbContext.Foods
                            .Include(f => f.OrderFoods)
                            .SingleOrDefaultAsync(f => f.Id == foodId))
                            .CheckIfFoodNull();

            if (dbFood.OrderFoods.Any())
            {
                dbFood.IsDeleted = true;
            }
            else
            {
                dbContext.Remove(dbFood);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Kép hozzáadása a megadott azonosítójú ételhez.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk,
        /// egyébként feltöltjük a képet és beállítjuk rá az étel relatív elérési útját.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        public async Task<string> UploadFoodImage(int foodId, UploadImageDto uploadedImage)
        {
            var dbFood = (await dbContext.Foods
                        .SingleOrDefaultAsync(f => f.Id == foodId))
                        .CheckIfFoodNull();

            string relativeImagePath = await imageRepository.UploadImage(uploadedImage.ImageFile, "Food");
            imageRepository.DeleteImage(dbFood.ImagePath);
            dbFood.ImagePath = relativeImagePath;

            await dbContext.SaveChangesAsync();

            return relativeImagePath;
        }

        /// <summary>
        /// A megadott azonosítójú étel képének törlése.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        public async Task DeleteFoodImage(int foodId)
        {
            var dbFood = (await dbContext.Foods
                        .SingleOrDefaultAsync(f => f.Id == foodId))
                        .CheckIfFoodNull();

            imageRepository.DeleteImage(dbFood.ImagePath);
            dbFood.ImagePath = null;

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// A megadott azonosítójú étel szerkesztése.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="food">A étel módosítandó adatai.</param>
        /// <returns>A módosított étel.</returns>
        public async Task<FoodDto> EditFood(int foodId, EditFoodDto food)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            dbFood.Price = food.Price;
            dbFood.Description = food.Description;
            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbFood).ToFoodDto();
        }

        /// <summary>
        /// Az étterem azonosítójának lekérdezése, amihez az étel tartozik.
        /// Ha a megadott azonosítóval étel nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étterem azonosítója.</returns>
        public async Task<int> GetFoodRestaurantId(int foodId)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            return dbFood.RestaurantId;
        }
    }

    /// <summary>
    /// Az ételhez kapcsolódó extension metódusok.
    /// </summary>
    internal static class FoodRepositoryExtensions
    {
        /// <summary>
        /// A étel típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="foods">Étel típusú lekérdezés.</param>
        /// <returns>Étel típusú adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<FoodDto>> ToFoodDtoList(this IQueryable<Food> foods)
        {
            return await foods.Select(f => new FoodDto(f)).ToListAsync();
        }

        /// <summary>
        /// Az étel modell osztály átalakítása adatátviteli objektummá.
        /// A metódus nem tartalmaz await operátort, így nem kéne async-nek lenni,
        /// de mivel a többi hasonló extension metódus (pl.: ToRestaurantDetialsDto()) tartalmaz ilyet,
        /// így az egységes kezelés/használat érdekében ebben az esetben is meghagytam az async jelzőt.
        /// </summary>
        /// <param name="food">Étel típusú entitás.</param>
        /// <returns>Étel típusú adatátviteli objektum.</returns>
#pragma warning disable CS1998
        public static async Task<FoodDto> ToFoodDto(this EntityEntry<Food> food)
#pragma warning restore CS1998
        {
            return new FoodDto(food.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott étel típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="food">Étel típusú modell osztáy.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Étel típusú modell osztáy.</returns>
        public static Food CheckIfFoodNull(this Food food,
            string errorMessage = "Az étel nem található.")
        {
            if (food == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return food;
        }
    }
}
