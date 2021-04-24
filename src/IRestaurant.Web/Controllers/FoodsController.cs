using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodManager foodManager;
        public FoodsController(FoodManager foodManager)
        {
            this.foodManager = foodManager;
        }

        [AllowAnonymous]
        [HttpGet("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> GetFood(int foodId)
        {
           return await foodManager.GetFood(foodId);
        }

        [AllowAnonymous]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await foodManager.GetRestaurantMenu(restaurantId);
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("restaurant/myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<FoodDto>> GetOwnerRestaurantMenu()
        {
            return await foodManager.GetOwnerRestaurantMenu();
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodDto>> AddFoodToRestaurantMenu([FromBody] CreateFoodDto food)
        {
            var createdFood =  await foodManager.AddFoodToMenu(food);
            return CreatedAtAction(nameof(GetFood), new { id = createdFood.Id }, createdFood);
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPost("{foodId}/image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UploadFoodImage(int foodId, [FromForm] UploadImageDto uploadedImage)
        {
            string relativeImagePath = await foodManager.UploadFoodImage(foodId, uploadedImage);
            return Ok(new { relativeImagePath });
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpDelete("{foodId}/image")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteFoodImage(int foodId)
        {
            await foodManager.DeleteFoodImage(foodId);
            return NoContent();
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPut("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> EditFood(int foodId, [FromBody] EditFoodDto food)
        {
            return await foodManager.EditFood(foodId, food);
        }

        [Authorize(Policy = UserRoles.Restaurant)]
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
