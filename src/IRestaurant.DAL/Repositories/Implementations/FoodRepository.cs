using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO;
using IRestaurant.DAL.DTO.Foods;
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
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImageRepository imageRepository;
        public FoodRepository(ApplicationDbContext dbContext, IImageRepository imageRepository)
        {
            this.dbContext = dbContext;
            this.imageRepository = imageRepository;
        }

        public async Task<FoodDto> GetFood(int foodId)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            return await dbContext.Entry(dbFood).ToFoodDto();
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await dbContext.Foods
                        .Where(f => f.RestaurantId == restaurantId)
                        .ToFoodDtoList();
        }

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

        public async Task DeleteFoodImage(int foodId)
        {
            var dbFood = (await dbContext.Foods
                        .SingleOrDefaultAsync(f => f.Id == foodId))
                        .CheckIfFoodNull();

            imageRepository.DeleteImage(dbFood.ImagePath);
            dbFood.ImagePath = null;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteFoodFromMenu(int foodId)
        {
            var dbFood = (await dbContext.Foods
                            .SingleOrDefaultAsync(f => f.Id == foodId))
                            .CheckIfFoodNull();

            dbContext.Remove(dbFood);
            await dbContext.SaveChangesAsync();
        }

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

        public async Task<int> GetFoodRestaurantId(int foodId)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            return dbFood.RestaurantId;
        }
    }

    internal static class FoodRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<FoodDto>> ToFoodDtoList(this IQueryable<Food> foods)
        {
            return await foods.Select(f => new FoodDto(f)).ToListAsync();
        }

        public static async Task<FoodDto> ToFoodDto(this EntityEntry<Food> food)
        {
            return new FoodDto(food.Entity);
        }

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
