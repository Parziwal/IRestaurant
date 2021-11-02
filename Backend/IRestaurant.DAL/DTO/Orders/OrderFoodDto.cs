using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// Egy rendelési tétel infromációit tartalmazó adatáviteli objektum.
    /// </summary>
    public class OrderFoodDto
    {
        /// <summary>
        /// Az étel neve.
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// Az étel ára.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// A rendelt mennyiség.
        /// </summary>
        public int Amount { get; set; }

        public OrderFoodDto() { }
        public OrderFoodDto(OrderFood orderFood)
        {
            this.FoodName = orderFood.Food.Name;
            this.Price = orderFood.Price;
            this.Amount = orderFood.Amount;
        }
    }
}
