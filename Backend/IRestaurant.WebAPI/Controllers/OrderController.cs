using IRestaurant.BLL.Managers;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.WebAPI.Controllers
{
    /// <summary>
    /// A rendeléselhez kapcsolódó adatok lekérdezése, módosítása és új rendelés létrehozása.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderManager orderManager;

        public OrderController(OrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        /// <summary>
        /// Az aktuális vendéghez tartozó rendelések áttekintő adatainak lekérdezése a keresési feltétel alapján.
        /// </summary>
        /// <param name="search">A rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>A vendég rendeléseinek áttekintő adatai.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("guest")]
        public async Task<PagedListDto<OrderOverviewDto>> GetGuestOrderOverviewList([FromQuery] OrderSearchDto search)
        {
            return await orderManager.GetGuestOrderOverviewList(search);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étteremhez leadott rendelések áttekintő adatainak
        /// lekérdezése a keresési feltétel alapján.
        /// </summary>
        /// <param name="search">A rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>Az étterem rendeléseinek áttekintő adatai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("restaurant")]
        public async Task<PagedListDto<OrderOverviewDto>> GetMyRestaurantOrderList([FromQuery] OrderSearchDto search)
        {
            return await orderManager.GetMyRestaurantOrderOverviewList(search);
        }

        /// <summary>
        /// A megadott azonosítójú rendelés részletes adatainak lekérdezése.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetails(int orderId)
        {
            return await orderManager.GetOrderDetails(orderId);
        }

        /// <summary>
        /// Rendelés létrehozása az aktuális vendéghez a megadott adatok alapján.
        /// </summary>
        /// <param name="order">A rendelés adatait.</param>
        /// <returns>a létrehozott rendelés részletes adatai.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetailsDto>> CreateOrder([FromBody]CreateOrder order)
        {
            var createdOrder = await orderManager.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderDetails), new { id = createdOrder.Id }, createdOrder);
        }

        /// <summary>
        /// A megadott azonosítójú rendelés státuszának módosítása.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <param name="status">A beállítandó státusz.</param>
        [HttpPatch("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeOrderStatus(int orderId, [FromQuery] OrderStatus status)
        {
            await orderManager.ChangeOrderStatus(orderId, status);
            return Ok();
        }
    }
}
