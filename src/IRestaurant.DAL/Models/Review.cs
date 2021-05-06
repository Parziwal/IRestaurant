using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez az adatmodell a felhasználói értékeléseket reprezentálja.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Az értékelés egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

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
        /// Az értéklés létrehozásának dátuma.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Az értékelés részletes leírás.
        /// </summary>
        [StringLength(10000)]
        public string Description { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója, amihez az érékelést írták.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója, aki az értékelést írta.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója, amihez az érékelést írták.
        /// </summary>
        [Required]
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója, aki az értékelést írta.
        /// </summary>
        [Required]
        public ApplicationUser User { get; set; }
    }
}
