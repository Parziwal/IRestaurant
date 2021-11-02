using IRestaurant.DAL.Models;

namespace IRestaurant.DAL.DTO.Foods
{
    /// <summary>
    /// Az éttermekhez tartozó ételek adatait tartalmazó adatáviteli objektum.
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

        public FoodDto() { }
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
