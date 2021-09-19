using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using System;
using System.Linq;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az étteremhez kapcsolódó összes adatot ebben a formátumban adjuk vissza a kliensnek. 
    /// </summary>
    public class RestaurantDetailsDto
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
        /// Az étteremről egy részletesebb leírás.
        /// </summary>
        public string DetailedDescription { get; set; }

        /// <summary>
        /// Az étteremhez tartozó kép elérési útja.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Az étterem címe.
        /// </summary>
        public AddressDto RestaurantAddress { get; set; }

        /// <summary>
        /// Az étterem tulajdonosának teljes neve.
        /// </summary>
        public string OwnerFullName { get; set; }

        /// <summary>
        /// Az étteremtől lehet-e rendelni, tehát a rendelési opció engedélyezve van-e.
        /// </summary>
        public bool IsOrderAvailable { get; set; }

        /// <summary>
        /// Az étterem az aktuálisan bejelentkezett felhasználó kedvence-e.
        /// </summary>
        public bool IsCurrentGuestFavourite { get; set; }

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása, illetve
        /// az eddigi felhasználói értékelésekből az étterem átlagos értékelésének kiszámítása.
        /// </summary>
        /// <param name="restaurant"></param>
        public RestaurantDetailsDto(Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = restaurant.Reviews.Any() ? Math.Round(restaurant.Reviews.Average(r => r.Rating), 2) : null;
            this.ShortDescription = restaurant.ShortDescription;
            this.DetailedDescription = restaurant.DetailedDescription;
            this.ImagePath = restaurant.ImagePath;
            this.RestaurantAddress = new AddressDto(restaurant.Address);
            this.OwnerFullName = restaurant.Owner.FullName;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
