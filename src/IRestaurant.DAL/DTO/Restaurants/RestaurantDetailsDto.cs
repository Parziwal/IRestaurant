﻿using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using System;
using System.Linq;

namespace IRestaurant.DAL.DTO.Restaurants
{
    public class RestaurantDetailsDto
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
        public bool IsCurrentGuestFavourite { get; set; }

        public RestaurantDetailsDto(Restaurant restaurant)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = restaurant.Reviews.Any() ? Math.Round(restaurant.Reviews.Average(r => r.Rating), 2) : null;
            this.ShortDescription = restaurant.ShortDescription;
            this.DetailedDescription = restaurant.DetailedDescription;
            this.ImagePath = restaurant.ImagePath;
            this.RestaurantAddress = new AddressDto(restaurant.Address);
            this.OwnerName = restaurant.Owner.FullName;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
