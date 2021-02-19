﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IRestaurant.DAL.Data;
using IRestaurant.BL;
using IRestaurant.DAL.DTO;
using IRestaurant.DAL.Repositories;
using System.Security.Claims;
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
        public async Task<IEnumerable<RestaurantOverview>> Get()
        {
            return await restaurantManager.ListRestaurantOverviews();
        }

        [HttpGet("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> Get(int restaurantId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var restaurant = await restaurantManager.GetRestaurantOrNull(userId, restaurantId);

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
        public async Task<ActionResult<Restaurant>> EditRestaurant([FromBody]EditRestaurant editRestaurant)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var restaurant = await restaurantManager.EditRestaurant(userId, editRestaurant);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/show")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ShowRestaurantForUsers()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await restaurantManager.ShowRestaurantForUsers(userId);

            if (!result)
            {
                NotFound();
            }

            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/hide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> HideRestaurantFromUsers()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await restaurantManager.HideRestaurantFromUsers(userId);

            if (!result)
            {
                NotFound();
            }

            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnofforder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> TurnOnOrderOption()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await restaurantManager.TurnOnOrderOption(userId);

            if (!result)
            {
                NotFound();
            }

            return Ok();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPut("myrestaurant/turnonorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> TurnOffOrderOption()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await restaurantManager.TurnOffOrderOption(userId);

            if (!result)
            {
                NotFound();
            }

            return Ok();
        }
    }
}
