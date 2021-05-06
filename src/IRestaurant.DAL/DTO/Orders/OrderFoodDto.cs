using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelési tétel ebben a formátumban kerül visszaküldésre a kliensnek.
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

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="orderFood">A rendelési tétel adatait tartalmazó modell osztály.</param>
        public OrderFoodDto(OrderFood orderFood)
        {
            this.FoodName = orderFood.Food.Name;
            this.Price = orderFood.Price;
            this.Amount = orderFood.Amount;
        }
    }
}
