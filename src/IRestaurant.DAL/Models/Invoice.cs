using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserFullName { get; set; }
        public Address UserAddress { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        [StringLength(50)]
        public string RestaurantName { get; set; }
        public Address RestaurantAddress { get; set; }
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
