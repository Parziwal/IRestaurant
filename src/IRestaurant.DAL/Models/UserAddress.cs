using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
