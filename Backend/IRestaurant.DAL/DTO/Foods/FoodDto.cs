using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Foods
{
    /// <summary>
    /// Az éttermekhez tartozó ételek ebben a formátmban kerülnek visszaküldésre a kliensnek.
    /// </summary>
    public class FoodDto
    {
        /// <summary>
        /// Az étel egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az étel neve.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Az étel ára.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Az étel leírása.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Az ételhez tartozó kép elérési útja.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="food">Étel adatait tartalmazó modell osztály.</param>

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
