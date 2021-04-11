using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime PreferredDeliveryDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
        public Invoice Invoice { get; set; }
    }
}
