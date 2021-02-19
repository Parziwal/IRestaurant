using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class EditRestaurant
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public IFormFile Image { get; set; }
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
    }
}
