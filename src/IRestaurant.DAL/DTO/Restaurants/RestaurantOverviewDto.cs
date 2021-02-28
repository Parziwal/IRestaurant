using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    public class RestaurantOverviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Rating { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string City { get; set; }

        public RestaurantOverviewDto(Models.Restaurant restaurant, double? rating)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = rating;
            this.ShortDescription = restaurant.ShortDescription;
            this.ImagePath = restaurant.ImagePath;
            this.City = restaurant.Address.City;
        }
    }
}
