using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az étterem elérehtőségének, illetve a rendelés állapotának értékét tartalmaó osztály.
    /// </summary>
    public class RestaurantSettingsDto
    {
        /// <summary>
        /// Az étterem elérhető-e a felhasználók számára.
        /// </summary>
        public bool ShowForUsers { get; set; }

        /// <summary>
        /// Az étteremtől lehet-e rendelni, tehát a rendelési opció engedélyezve van-e.
        /// </summary>
        public bool IsOrderAvailable { get; set; }

        public RestaurantSettingsDto() { }

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="restaurant">Az étterem adatait tartalmazó modell osztály.</param>
        public RestaurantSettingsDto(Restaurant restaurant)
        {
            this.ShowForUsers = restaurant.ShowForUsers;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
