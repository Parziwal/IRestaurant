using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Rating { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string ImagePath { get; set; }
        public AddressDto RestaurantAddress { get; set; }
        public string OwnerName { get; set; }
        public bool IsOrderAvailable { get; set; }

        public RestaurantDto(Restaurant restaurant, ApplicationUser owner, double? rating)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = rating;
            this.ShortDescription = restaurant.ShortDescription;
            this.DetailedDescription = restaurant.DetailedDescription;
            this.ImagePath = restaurant.ImagePath;
            this.RestaurantAddress = new AddressDto(restaurant.Address);
            this.OwnerName = owner.FullName;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
