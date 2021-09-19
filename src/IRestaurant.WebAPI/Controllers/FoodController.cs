using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRestaurant.WebAPI.Controllers
{
    /// <summary>
    /// Az étteremhez tartozó ételekkel kapcsolatos adatok lekérdezése, módosítása és törlése.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodManager foodManager;

        /// <summary>
        /// A szükséges üzleti logikai függőségek elkérése.
        /// </summary>
        /// <param name="foodManager">Az ételeket kezeli.</param>
        public FoodController(FoodManager foodManager)
        {
            this.foodManager = foodManager;
        }

        /// <summary>
        /// A megadott azonosítójú étel adatainak lekérdezése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <returns>Az étel adatai.</returns>
        [AllowAnonymous]
        [HttpGet("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> GetFood(int foodId)
        {
           return await foodManager.GetFood(foodId);
        }

        /// <summary>
        /// A megadott azonosítójú éteremhez tartozó ételek lekérdezése.
        /// </summary>
        /// <param name="restaurantId">Az étterem egyedi azonosítója.</param>
        /// <returns>Az étteremhez tartozó ételek listája.</returns>
        [AllowAnonymous]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<FoodDto>> GetRestaurantMenu(int restaurantId)
        {
            return await foodManager.GetRestaurantMenu(restaurantId);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem ételeinek lekérése.
        /// </summary>
        /// <returns>Az aktuális felhasználó éttermének ételei.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("restaurant/myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<FoodDto>> GetMyRestaurantMenu()
        {
            return await foodManager.GetMyRestaurantMenu();
        }

        /// <summary>
        /// Étel hozzáadása az aktuális felhasználóhoz tartozó étteremhez.
        /// </summary>
        /// <param name="food">A létrehozandó étel adatai.</param>
        /// <returns>A létrehozott étel adatai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodDto>> AddFoodToRestaurantMenu([FromBody] CreateFoodDto food)
        {
            var createdFood =  await foodManager.AddFoodToMenu(food);
            return CreatedAtAction(nameof(GetFood), new { id = createdFood.Id }, createdFood);
        }

        /// <summary>
        /// Kép feltöltése a megadott azonosítójú ételhez.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útja.</returns>
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

        /// <summary>
        /// Kép törlése a megadott azonosítójú étel esetében.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
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

        /// <summary>
        /// A megadott azonosítójú étel adatainak módosítása.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
        /// <param name="food">Az étel módosítandó adatai.</param>
        /// <returns>A módosított étel.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPut("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FoodDto>> EditFood(int foodId, [FromBody] EditFoodDto food)
        {
            return await foodManager.EditFood(foodId, food);
        }

        /// <summary>
        /// A megadott azonosítójú étel törlése.
        /// </summary>
        /// <param name="foodId">Az étel azonosítója.</param>
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
