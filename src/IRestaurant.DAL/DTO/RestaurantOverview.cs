using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class RestaurantOverview
    {
        public int Id { get; }
        [StringLength(50)]
        public string Name { get; }
        public double? Rating { get; }
        [StringLength(200)]
        public string ShortDescription { get; }
        public string ImagePath { get; }
        [StringLength(50)]
        public string City { get; }

        public RestaurantOverview(Models.Restaurant restaurant, double? rating)
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
