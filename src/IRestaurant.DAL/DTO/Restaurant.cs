﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class Restaurant
    {
        public int Id { get; }
        public string Name { get; }
        public double? Rating { get; }
        public string ShortDescription { get; }
        public string DetailedDescription { get; }
        public string ImagePath { get; }
        public int? ZipCode { get; }
        public string City { get; }
        public string Street { get; }
        public string PhoneNumber { get; }
        public string OwnerName { get; }
        public bool IsOrderAvailable { get; }

        public Restaurant(Models.Restaurant restaurant, Models.ApplicationUser owner)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = restaurant.Rating;
            this.ShortDescription = restaurant.ShortDescription;
            this.DetailedDescription = restaurant.DetailedDescription;
            this.ImagePath = restaurant.ImagePath;
            this.ZipCode = restaurant.ZipCode;
            this.City = restaurant.City;
            this.Street = restaurant.Street;
            this.OwnerName = owner.FullName;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
