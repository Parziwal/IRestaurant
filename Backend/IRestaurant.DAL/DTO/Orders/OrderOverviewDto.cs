using IRestaurant.DAL.Models;
using System;
using System.Linq;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelés áttekintő adatait tartalmazó adatáviteli objektum.
    /// </summary>
    public class OrderOverviewDto
    {
        /// <summary>
        /// A rendelés egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A rendelés létrehozásának dátuma.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A felhasználó által megadott kívánt kiszállítási dátum.
        /// </summary>
        public DateTime PreferredDeliveryDate { get; set; }

        /// <summary>
        /// A rendelés státusza.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// A rendelés összértéke.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Annak a felhasználónak a teljes neve, aki a rendelést leadta.
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        /// Az étterem neve, ahonnét rendeltek.
        /// </summary>
        public string RestaurantName { get; set; }

        public OrderOverviewDto() { }
        public OrderOverviewDto(Order order)
        {
            this.Id = order.Id;
            this.CreatedAt = order.CreatedAt;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.Status;
            this.Total = order.OrderFoods.Sum(of => of.Amount * of.Price);
            this.UserFullName = order.Invoice.UserFullName;
            this.RestaurantName = order.Invoice.RestaurantName;
        }
    }
}
