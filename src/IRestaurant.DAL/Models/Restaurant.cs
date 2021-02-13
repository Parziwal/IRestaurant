using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [Range(1000, 10000)]
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
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public ICollection<Food> Foods { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
