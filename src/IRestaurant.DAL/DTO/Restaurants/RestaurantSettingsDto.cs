using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    public class RestaurantSettingsDto
    {
        public bool showForUsers { get; set; }
        public bool IsOrderAvailable { get; set; }

        public RestaurantSettingsDto(Restaurant restaurant) {
            this.showForUsers = restaurant.ShowForUsers;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
