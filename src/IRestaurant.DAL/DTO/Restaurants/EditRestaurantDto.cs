using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IFormFile Image { get; set; }
        [Required]
        public CreateOrEditAddressDto Address { get; set; }
    }
}
