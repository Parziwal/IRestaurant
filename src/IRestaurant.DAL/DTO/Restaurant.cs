using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class Restaurant
    {
        public int Id { get; }
        [StringLength(50)]
        public string Name { get; }
        public double? Rating { get; }
        [StringLength(200)]
        public string ShortDescription { get; }
        [StringLength(10000)]
        public string DetailedDescription { get; }
        public string ImagePath { get; }
        [Range(1000, 9999)]
        public int? ZipCode { get;}
        [StringLength(50)]
        public string City { get; }
        [StringLength(100)]
        public string Street { get; }
        [Phone]
        public string PhoneNumber { get; }
        public string OwnerName { get; }
        [Required]
        public bool IsOrderAvailable { get; }

        public Restaurant(Models.Restaurant restaurant, Models.ApplicationUser owner, double? rating)
        {
            this.Id = restaurant.Id;
            this.Name = restaurant.Name;
            this.Rating = rating;
            this.ShortDescription = restaurant.ShortDescription;
            this.DetailedDescription = restaurant.DetailedDescription;
            this.ImagePath = restaurant.ImagePath;
            this.ZipCode = restaurant.Address.ZipCode;
            this.City = restaurant.Address.City;
            this.Street = restaurant.Address.Street;
            this.OwnerName = owner.FullName;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
