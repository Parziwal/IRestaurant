using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Orders
{
    public class OrderFoodDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public OrderFoodDto(OrderFood orderFood)
        {
            this.Name = orderFood.Food.Name;
            this.Price = orderFood.Price;
            this.Amount = orderFood.Amount;
        }
    }
}
