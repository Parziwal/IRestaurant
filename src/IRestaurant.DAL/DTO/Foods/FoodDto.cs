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
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public string Description { get; }
        public string ImagePath { get; }

        public FoodDto(Food food)
        {
            this.Id = food.Id;
            this.Name = food.Name;
            this.Price = food.Price;
            this.Description = food.Description;
            this.ImagePath = food.ImagePath;
        }
    }
}
