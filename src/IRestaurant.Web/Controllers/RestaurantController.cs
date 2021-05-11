using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.DTO.Restaurants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Images;

namespace IRestaurant.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantManager restaurantManager;

        public RestaurantController(RestaurantManager restaurantManager)
        {
            this.restaurantManager = restaurantManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RestaurantOverviewDto>> GetRestaurantOverviewList([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetRestaurantOverviewList(restaurantName);
        }

        [AllowAnonymous]
        [HttpGet("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaurantDetailsDto>> GetRestaurantDetails(int restaurantId)
        {
            return await restaurantManager.GetRestaurantDetails(restaurantId);
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RestaurantDetailsDto>> GetMyRestaurantDetails()
        {
            return await restaurantManager.GetMyRestaurantDetails();
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPut("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDetailsDto>> EditMyRestaurant([FromBody]EditRestaurantDto editRestaurant)
        {
            return await restaurantManager.EditMyRestaurant(editRestaurant);
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpPost("myrestaurant/image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UploadMyRestaurantImage([FromForm] UploadImageDto uploadedImage)
        {
            string relativeImagePath = await restaurantManager.UploadMyRestaurantImage(uploadedImage);
            return Ok(new { relativeImagePath });
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpDelete("myrestaurant/image")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMyRestaurantImage()
        {
            await restaurantManager.DeleteMyRestaurantImage();
            return NoContent();
        }

        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("myrestaurant/settings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantSettingsDto>> GetMyRestaurantSettings()
        {
            return await restaurantManager.GetMyRestaurantSettings();
        }

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

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("favourite")]
        public async Task<IEnumerable<RestaurantOverviewDto>> GetGuestFavouriteRestaurantList([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetUserFavouriteRestaurantList(restaurantName);
        }

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
