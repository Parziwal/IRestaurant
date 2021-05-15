using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Web.Controllers
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

        /// <summary>
        /// A szükséges üzleti logikai függőségek elkérése.
        /// </summary>
        /// <param name="orderManager">A rendeléseket kezeli.</param>
        public OrderController(OrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        /// <summary>
        /// Az aktuális vendéghez tartozó rendelések áttekintő adatainak lekérdezése.
        /// </summary>
        /// <returns>A vendég rendeléseinek áttekintő adatai.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("guest")]
        public async Task<IEnumerable<OrderOverviewDto>> GetGuestOrderOverviewList()
        {
            return await orderManager.GetGuestOrderOverviewList();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étteremhez leadott rendelések áttekintő adatainak lekérdezése.
        /// </summary>
        /// <returns>Az étterem rendeléseinek áttekintő adatai.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("restaurant")]
        public async Task<IEnumerable<OrderOverviewDto>> GetMyRestaurantOrderList()
        {
            return await orderManager.GetMyRestaurantOrderOverviewList();
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
