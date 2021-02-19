using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public double? Rating { get; set; }
        [Required]
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [Range(1000, 9999)]
        public int ZipCode { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string OwnerName { get; set; }
        [Required]
        public bool ShowForUsers { get; set; }
        [Required]
        public bool IsOrderAvailable { get; set; }

        public RestaurantDto(Models.Restaurant restaurant, Models.ApplicationUser owner, double? rating)
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
            this.ShowForUsers = restaurant.ShowForUsers;
            this.IsOrderAvailable = restaurant.IsOrderAvailable;
        }
    }
}
