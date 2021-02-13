using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class Food
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
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
