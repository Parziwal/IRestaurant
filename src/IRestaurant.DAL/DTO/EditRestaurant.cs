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
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public IFormFile Image { get; set; }
        [Range(1000, 9999)]
        public int? ZipCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
