using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.DTO.Restaurants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Images;

namespace IRestaurant.WebAPI.Controllers
{
    /// <summary>
    /// Az étteremek adatainak lekérdezése, módosítása és a kedvenc étteremek kezelése.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantManager restaurantManager;

        /// <summary>
        /// A szükséges üzleti logikai függőségek elkérése.
        /// </summary>
        /// <param name="restaurantManager">Az éttermeket kezeli.</param>
        public RestaurantController(RestaurantManager restaurantManager)
        {
            this.restaurantManager = restaurantManager;
        }

        /// <summary>
        /// A megadott névre illeszkedő elérhető éttermek áttekintő adatainak lekérdezése.
        /// Ha a keresett név null, akkor az összes elérhető étteremet visszaadja.
        /// </summary>
        /// <param name="restaurantName">A keresett étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RestaurantOverviewDto>> GetRestaurantOverviewList([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetRestaurantOverviewList(restaurantName);
        }

        /// <summary>
        /// A megadott azonosítójú étterem részletes adatainak lekérdezése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étterem részletes adatai.</returns>
        [AllowAnonymous]
        [HttpGet("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaurantDetailsDto>> GetRestaurantDetails(int restaurantId)
        {
            return await restaurantManager.GetRestaurantDetails(restaurantId);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem részletes adatainak lekérdezése.
        /// </summary>
        /// <returns>Az étterem részletes adatai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaurantDetailsDto>> GetMyRestaurantDetails()
        {
            return await restaurantManager.GetMyRestaurantDetails();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem adatainak módosítása.
        /// </summary>
        /// <param name="editRestaurant">Az étterem módosítandó adatai.</param>
        /// <returns>Az étterem módosított részletes adatai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPut("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDetailsDto>> EditMyRestaurant([FromBody]EditRestaurantDto editRestaurant)
        {
            return await restaurantManager.EditMyRestaurant(editRestaurant);
        }

        /// <summary>
        /// Kép feltöltése az aktuális felhasználóhoz tartozó étteremhez.
        /// </summary>
        /// <param name="uploadedImage">A feltöltendő kép.</param>
        /// <returns>A kép relatív elérési útvonala.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPost("myrestaurant/image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UploadMyRestaurantImage([FromForm] UploadImageDto uploadedImage)
        {
            string relativeImagePath = await restaurantManager.UploadMyRestaurantImage(uploadedImage);
            return Ok(new { relativeImagePath });
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem képének törlése.
        /// </summary>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpDelete("myrestaurant/image")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMyRestaurantImage()
        {
            await restaurantManager.DeleteMyRestaurantImage();
            return NoContent();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem beállítási adatainak lekérdezése.
        /// </summary>
        /// <returns>Az étterem beállításainak állapotai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("myrestaurant/settings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantSettingsDto>> GetMyRestaurantSettings()
        {
            return await restaurantManager.GetMyRestaurantSettings();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem elérhetővé tétele a felhasználók számára.
        /// </summary>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPatch("myrestaurant/show")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ShowMyRestaurantForUsers()
        {
            await restaurantManager.ShowMyRestaurantForUsers();
            return Ok();
        }


        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem elrejtése, levétele a publikusan elérhető éttermek listájából.
        /// </summary>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPatch("myrestaurant/hide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> HideMyRestaurantFromUsers()
        {
            await restaurantManager.HideMyRestaurantForUsers();
            return Ok();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének bekapcsolása.
        /// </summary>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPatch("myrestaurant/order/turnon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TurnOnOrderOption()
        {
            await restaurantManager.TurnOnMyRestaurantOrderStatus();
            return Ok();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem rendelési lehetőségének kikapcsolása.
        /// </summary>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPatch("myrestaurant/order/turnoff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TurnOffOrderOption()
        {
            await restaurantManager.TurnOffMyRestaurantOrderStatus();
            return Ok();
        }

        /// <summary>
        /// Az aktuális vendég kedvenc éttermeinek, azok áttekintő adatainak lekérdezése,
        /// ami a szűrési feltételként megadott névre illeszkedik.
        /// Ha a keresett név null, akkor az összes kedvenc étteremet visszaadja.
        /// </summary>
        /// <param name="restaurantName">A keresett étterem neve.</param>
        /// <returns>Az étteremek áttekintő adatait tartalamazó lista.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("favourite")]
        public async Task<IEnumerable<RestaurantOverviewDto>> GetGuestFavouriteRestaurantList([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetUserFavouriteRestaurantList(restaurantName);
        }

        /// <summary>
        /// A megadott azonosítójú étterem felvétele az aktuális vendég kedvencei közé.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost("favourite/add/{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddRestaurantToGuestFavourite(int restaurantId)
        {
            await restaurantManager.AddRestaurantToUserFavourite(restaurantId);
            return Ok();
        }

        /// <summary>
        /// A megadott azonosítójú étterem eltávolítása törlése az aktuális vendég kedvencei közül.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpDelete("favourite/remove/{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveRestaurantFromGuestFavourite(int restaurantId)
        {
            await restaurantManager.RemoveRestaurantFromUserFavourite(restaurantId);
            return NoContent();
        }
    }
}
