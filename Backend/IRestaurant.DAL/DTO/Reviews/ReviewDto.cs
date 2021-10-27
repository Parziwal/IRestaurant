using IRestaurant.DAL.Models;
using System;

namespace IRestaurant.DAL.DTO.Reviews
{
    /// <summary>
    /// Az értékelés adatait a kliens ebben a formában kapja meg.
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Az értékelés egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az értékelés osztályzata egy 1-től 5-ig terjedő skálán.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Az értékelés címe.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Az értéklés létrehozásának dátuma.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Az értékelés részletes leírás.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója, aki az értékelést írta.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A felhasználó neve, aki az értékelést írta.
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója, amihez az érékelést írták.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Az étterem neve, amihez az érékelést írták.
        /// </summary>
        public string RestaurantName { get; set; }

        public ReviewDto() { }

        /// <summary>
        /// A konstruktorban átadott modell osztály alapján a tulajdonságok beállítása.
        /// </summary>
        /// <param name="review">Az értékelés adatait tartalmazó modell osztály.</param>
        public ReviewDto(Review review)
        {
            this.Id = review.Id;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.CreatedAt = review.CreatedAt;
            this.Description = review.Description;
            this.UserId = review.User.Id;
            this.UserFullName = review.User.FullName;
            this.RestaurantId = review.Restaurant.Id;
            this.RestaurantName = review.Restaurant.Name;
        }
    }
}
