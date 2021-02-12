using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Address
    {
        public int Id { get; set; }
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
        public int UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
