using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelés részletes adatai ebben a formátumban kerülnek visszaküldésre a kliensnek.
    /// </summary>
    public class OrderDetailsDto : OrderOverviewDto
    {
        /// <summary>
        /// A rendelést leadó felhasználó számlázási/kiszállítási címe.
        /// </summary>
        public AddressDto UserAddress { get; set; }

        /// <summary>
        /// Az étterem címe, ahonnét rendeltek.
        /// </summary>
        public AddressDto RestaurantAddress { get; set; }

        /// <summary>
        /// A rendelt tételek listája.
        /// </summary>
        public List<OrderFoodDto> OrderFoods { get; set; }


        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="order">Rendelés adatait tartalmazó modell osztály.</param>

        public OrderDetailsDto(Order order) : base(order)
        {
            this.UserAddress = new AddressDto(order.Invoice.UserAddress);
            this.RestaurantAddress = new AddressDto(order.Invoice.RestaurantAddress);
            this.OrderFoods = order.OrderFoods.Select(of => new OrderFoodDto(of)).ToList();
        }
    }
}
