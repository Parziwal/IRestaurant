using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class Food
    {
        public int Id { get; }
        [Required]
        [StringLength(50)]
        public string Name { get; }
        [Required]
        public int Price { get; }
        [Required]
        [StringLength(1000)]
        public string Description { get; }

        public Food(Models.Food food)
        {
            this.Id = food.Id;
            this.Name = food.Name;
            this.Price = food.Price;
            this.Description = food.Description;
        }
    }
}
