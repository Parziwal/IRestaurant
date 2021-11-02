using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az étterem beállítási adatait tartalmaó adatátviteli objektum.
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
        public RestaurantSettingsDto(Restaurant restaurant)
        {
            this.ShowForUsers = restaurant.ShowForUsers;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
