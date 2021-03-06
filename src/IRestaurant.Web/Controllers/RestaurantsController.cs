using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IRestaurant.BL;
using IRestaurant.DAL.DTO.Restaurants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IRestaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantManager restaurantManager;

        public RestaurantsController(RestaurantManager restaurantManager)
        {
            this.restaurantManager = restaurantManager;
        }

        [HttpGet]
        public async Task<IEnumerable<RestaurantOverviewDto>> GetRestaurantList([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetRestaurantOverviews(restaurantName);
        }

        [HttpGet("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
        {
            return await restaurantManager.GetRestaurant(restaurantId);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpGet("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> GetMyRestaurant()
        {
            return await restaurantManager.GetMyRestaurant();
        }

        [Authorize( Roles = "Restaurant" )]
        [HttpPut("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> EditMyRestaurant([FromBody]EditRestaurantDto editRestaurant)
        {
            return await restaurantManager.EditMyRestaurant(editRestaurant);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/show")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ShowMyRestaurantForUsers()
        {
            await restaurantManager.ChangeMyRestaurantShowStatus(true);
            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/hide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> HideMyRestaurantFromUsers()
        {
            await restaurantManager.ChangeMyRestaurantShowStatus(false);
            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnonorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> TurnOnOrderOption()
        {
            await restaurantManager.ChangeMyRestaurantOrderStatus(true);
            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnofforder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> TurnOffOrderOption()
        {
            await restaurantManager.ChangeMyRestaurantOrderStatus(false);
            return Ok();
        }
    }
}
