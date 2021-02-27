using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Foods
{
    public class FoodDto
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
        public string ImagePath { get; set; }

        public FoodDto(Models.Food food)
        {
            this.Id = food.Id;
            this.Name = food.Name;
            this.Price = food.Price;
            this.Description = food.Description;
            this.ImagePath = food.ImagePath;
        }
    }
}
