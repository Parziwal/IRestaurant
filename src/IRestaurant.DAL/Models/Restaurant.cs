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
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public string ImagePath { get; set; }
        [Range(1000, 9999)]
        public int ZipCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public bool ShowForUsers { get; set; }
        [Required]
        public bool IsOrderAvailable { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
