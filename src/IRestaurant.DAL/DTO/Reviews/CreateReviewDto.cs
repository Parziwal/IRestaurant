using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Reviews
{
    /// <summary>
    /// Az értéklés létrehozásához ezen osztálynak megfelelő formátumban várjuk az adatokat.
    /// </summary>
    public class CreateReviewDto
    {
        /// <summary>
        /// Az étterem egyedi azonosítója.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Az értékelés osztályzata egy 1-től 5-ig terjedő skálán.
        /// </summary>
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        /// <summary>
        /// Az értékelés címe.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// Az értékelés részletes leírás.
        /// </summary>
        [StringLength(10000)]
        public string Description { get; set; }
    }
}
