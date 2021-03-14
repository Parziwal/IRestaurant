using IRestaurant.BL;
using IRestaurant.DAL.DTO.Foods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodManager foodManager;
        public FoodsController(FoodManager foodManager)
        {
            this.foodManager = foodManager;
        }

        [HttpGet("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> Get(int foodId)
        {
           return await foodManager.GetFood(foodId);
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await foodManager.GetRestaurantMenu(restaurantId);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpGet("restaurant/myrestaurant")]
        public async Task<IEnumerable<FoodDto>> GetOwnerRestaurantMenu()
        {
            return await foodManager.GetOwnerRestaurantMenu();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodDto>> AddFoodToRestaurantMenu([FromBody] CreateFoodDto food)
        {
            var createdFood =  await foodManager.AddFoodToMenu(food);
            return CreatedAtAction(nameof(Get), new { id = createdFood.Id }, createdFood);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> EditFood(int foodId, [FromBody] EditFoodDto food)
        {
            return await foodManager.EditFood(foodId, food);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpDelete("{foodId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveFoodFromRestaurantMenu(int foodId)
        {
            await foodManager.DeleteFoodFromMenu(foodId);
            return NoContent();
        }
    }
}
