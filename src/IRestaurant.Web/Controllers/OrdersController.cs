using IRestaurant.BL.Managers;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderManager orderManager;

        public OrdersController(OrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderOverviewDto>> GetUserOrders()
        {
            return await orderManager.GetUserOrders();
        }

        [HttpGet]
        public async Task<IEnumerable<OrderOverviewDto>> GetOrdersBelongsToMyRestaurant()
        {
            return await orderManager.GetOrdersBelongsToMyRestaurant();
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> GetOrderDetails(int orderId)
        {
            return await orderManager.GetOrderDetails(orderId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrder order)
        {
            var createdOrder = await orderManager.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderDetails), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPatch("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeOrderStatus(int orderId, [FromQuery] Status status)
        {
            await orderManager.ChangeOrderStatus(orderId, status);
            return Ok();
        }
    }
}
