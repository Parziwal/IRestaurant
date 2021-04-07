﻿using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        public FoodRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FoodDto> GetFood(int foodId)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            return dbFood.GetFood();
        }

        public async Task<IReadOnlyCollection<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await dbContext.Foods.Where(f => f.RestaurantId == restaurantId).GetFoods();
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

            return dbFood.GetFood();
        }

        public async Task<FoodDto> DeleteFoodFromMenu(int foodId)
        {
            var dbFood = (await dbContext.Foods
                            .SingleOrDefaultAsync(f => f.Id == foodId))
                            .CheckIfFoodNull();

            dbContext.Remove(dbFood);
            await dbContext.SaveChangesAsync();

            return dbFood.GetFood();
        }

        public async Task<FoodDto> EditFood(int foodId, EditFoodDto food)
        {
            var dbFood = (await dbContext.Foods
                                .SingleOrDefaultAsync(f => f.Id == foodId))
                                .CheckIfFoodNull();

            dbFood.Price = food.Price;
            dbFood.Description = food.Description;
            await dbContext.SaveChangesAsync();

            return dbFood.GetFood();
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
        public static async Task<IReadOnlyCollection<FoodDto>> GetFoods(this IQueryable<Food> foods)
        {
            return await foods.Select(f => GetFood(f)).ToListAsync();
        }

        public static FoodDto GetFood(this Food food)
        {
            return new FoodDto(food);
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
