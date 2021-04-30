using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Foods
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

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
