using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Orders
{
    public class CreateOrder
    {
        [Required]
        public DateTime PreferredDeliveryDate { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public List<CreateOrderFood> OrderFoods { get; set; } 
    }
}
