using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
