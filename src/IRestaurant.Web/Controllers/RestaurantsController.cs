using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IRestaurant.BL;
using IRestaurant.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IEnumerable<RestaurantOverviewDto>> Get([FromQuery] string restaurantName = null)
        {
            return await restaurantManager.GetRestaurantOverviews(restaurantName);
        }

        [HttpGet("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> Get(int restaurantId)
        {
            var restaurant = await restaurantManager.GetRestaurantOrNull(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(restaurant);
            }
        }

        [Authorize(Roles = "Restaurant")]
        [HttpGet("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> GetMyRestaurant()
        {
            var restaurant = await restaurantManager.GetOwnerRestaurantOrNull();

            if (restaurant == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(restaurant);
            }
        }

        [Authorize( Roles = "Restaurant" )]
        [HttpPut("myrestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> EditRestaurant([FromBody]EditRestaurantDto editRestaurant)
        {
            var restaurant = await restaurantManager.EditRestaurant(editRestaurant);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/show")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ShowRestaurantForUsers()
        {
            try
            {
                await restaurantManager.ShowRestaurantForUsers();
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/hide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> HideRestaurantFromUsers()
        {
            try
            {
                await restaurantManager.HideRestaurantFromUsers();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnofforder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TurnOnOrderOption()
        {
            try
            {
                await restaurantManager.TurnOnOrderOption();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnonorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TurnOffOrderOption()
        {
            try
            {
                await restaurantManager.TurnOffOrderOption();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
