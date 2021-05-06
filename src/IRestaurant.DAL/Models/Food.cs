using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály reprezentálja az ételeket, amiket az éttermek felvesznek az étlapjukra.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Az étel egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az étel neve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Az étel ára.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        /// <summary>
        /// Az étel leírása.
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Az ételhez tartozó kép elérési útja.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Azt jelzi, hogy az ételt törölte az étterem, de az adatbázisból nem törölhető, mivel van rá vonatkozó rendelés.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója, amihez az étel tartozik.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Az étterem, amihez az étel tartozik.
        /// </summary>
        [Required]
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// A rendelési tételek listája, amihez az étel tartozik.
        /// </summary>
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
