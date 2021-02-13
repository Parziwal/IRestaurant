using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class RestaurantOverview
    {
        public int Id { get; }
        public string Name { get; }
        public string ShortDescription { get; }
        public string ImagePath { get; }
        public string City { get; }

        public RestaurantOverview(Models.Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.ShortDescription = restaurant.ShortDescription;
            this.ImagePath = restaurant.ImagePath;
            this.City = restaurant.City;
        }
    }
}
