using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Orders
{
    public class CreateOrderFood
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
