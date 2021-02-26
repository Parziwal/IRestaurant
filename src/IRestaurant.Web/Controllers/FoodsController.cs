using IRestaurant.BL;
using IRestaurant.DAL.DTO.Food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<ActionResult<FoodDto>> Get(int foodId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var food = await foodManager.GetFood(userId, foodId);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
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
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await foodManager.GetOwnerRestaurantMenu(userId);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> AddFoodToRestaurantMenu([FromBody] CreateFoodDto food)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var createdFood =  await foodManager.AddFoodToMenu(userId, food);

            if (createdFood == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = createdFood.Id }, createdFood);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodDto>> EditFood(int foodId, [FromBody] EditFoodDto food)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var editedFood = await foodManager.EditFood(userId, foodId, food);

            if (editedFood == null)
            {
                return NotFound();
            }

            return Ok(editedFood);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpDelete("{foodId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveFoodFromRestaurantMenu(int foodId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var deletedFood = await foodManager.DeleteFoodFromMenu(userId, foodId);

            if (deletedFood == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
