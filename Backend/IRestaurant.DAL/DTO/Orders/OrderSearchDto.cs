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
        private string restaurantName = "";

        /// <summary>
        /// A rendeléshez tartozó étterem nevében tartalmazandó kifejezés.
        /// </summary>
        public string RestaurantName
        {
            get { return restaurantName; }
            set { restaurantName = value == null ? "" : value; }
        }

        private string guestName = "";

        /// <summary>
        /// A rendeléshez tartozó vendég nevében tartalmazandó kifejezés.
        /// </summary>
        public string GuestName
        {
            get { return guestName; }
            set { guestName = value == null ? "" : value; }
        }

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

        /// <summary>
        /// A rendelések, amiknek a létrehozási ideje nagyobb, mint a megadott dátum.
        /// </summary>
        public DateTime OrderMinDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// A rendelések, amiknek a létrehozási ideje kisebb, mint a megadott dátum.
        /// </summary>
        public DateTime OrderMaxDate { get; set; } = DateTime.Now;
    }
}
