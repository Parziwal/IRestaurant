using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály tartalmazza azon felhasználó és étterem párosokat, amiket a vendég kedvencének jelölt.
    /// </summary>
    public class FavouriteRestaurant
    {
        /// <summary>
        /// A felhasználó és étterem páros egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// A felhasználó.
        /// </summary>
        [Required]
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Az étterem.
        /// </summary>
        [Required]
        public Restaurant Restaurant { get; set; }
    }
}
