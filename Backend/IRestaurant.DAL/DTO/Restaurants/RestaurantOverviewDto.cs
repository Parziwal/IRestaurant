using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az étterem áttekintő a adatait a kliens ebben a formátumban kapja meg.
    /// </summary>
    public class RestaurantOverviewDto
    {
        /// <summary>
        /// Az étterem egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az étterem neve.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Az étterem aggregált értékelése az eddigi felhasználói értékelések alapján.
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// Az étteremről egy rövidebb, pár mondatos ismertető.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Az étteremhez tartozó kép elérési útja.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// A város neve, ahol az étterem található.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása, illetve
        /// az eddigi felhasználói értékelésekből az étterem átlagos értékelésének kiszámítása.
        /// </summary>
        /// <param name="restaurant"></param>
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
