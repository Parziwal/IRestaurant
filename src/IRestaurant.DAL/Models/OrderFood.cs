using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class OrderFood
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Food Food { get; set; }
    }
}
