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
        public Status status { get; set; }
        public int AddressId { get; set; }
        public int RestaurantId { get; set; }
        public int PaymentMethodId { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
