using IRestaurant.DAL.DTO.Addresses;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Restaurants
{
    public class EditRestaurantDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(300)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        [Required]
        public CreateOrEditAddressDto Address { get; set; }
    }
}
