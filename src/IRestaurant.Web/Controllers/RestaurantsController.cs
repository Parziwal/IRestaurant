using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IRestaurant.DAL.Data;
using IRestaurant.BL;
using IRestaurant.DAL.DTO;

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
        public async Task<IEnumerable<RestaurantOverview>> Get()
        {
            return await restaurantManager.ListRestaurantOverviews();
        }

        [HttpGet("{restaurantId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Restaurant>> Get(int restaurantId)
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
    }
}
