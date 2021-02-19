using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    [Owned]
    public class Address
    {
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
