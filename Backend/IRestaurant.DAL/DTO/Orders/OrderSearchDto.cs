using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelésre vonatkozó keresési feltételeket tartalmazó osztály.
    /// </summary>
    public class OrderSearchDto : PageDto
    {
        /// <summary>
        /// A keresett rendelési státuszok.
        /// </summary>
        public List<OrderStatus> Statuses { get; set; } = new List<OrderStatus>
        {
            OrderStatus.PROCESSING,
            OrderStatus.ORDER_COMPLETION,
            OrderStatus.UNDER_DELIVERING,
            OrderStatus.DELIVERED,
            OrderStatus.CANCELLED
        };

        /// <summary>
        /// A rendelések rendezési sorrendje.
        /// </summary>
        public string SortBy { get; set; } = OrderSortBy.PREFFERED_DELIVERY_DATE_DESC.ToString();
    }
}
