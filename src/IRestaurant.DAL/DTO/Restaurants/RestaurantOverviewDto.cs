using IRestaurant.DAL.Models;
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

        public RestaurantOverviewDto(Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = restaurant.Reviews.Any() ? Math.Round(restaurant.Reviews.Average(r => r.Rating), 2) : null;
            this.ShortDescription = restaurant.ShortDescription;
            this.ImagePath = restaurant.ImagePath;
            this.City = restaurant.Address.City;
        }
    }
}
