using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.Extensions;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// Az éttermekhez tartozó ételekkel kapcsolatos adatok lekéréséért és kezeléséért felelős.
    /// </summary>
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageRepository imageRepository;

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
                        .OrderBy(f => f.Name)
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

            string relativeImagePath = await imageRepository.UploadImage(uploadedImage.ImageFile, "food");
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
}
