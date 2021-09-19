using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály reprezentál egy tételt a rendelésben.
    /// </summary>
    public class OrderFood
    {
        /// <summary>
        /// A rendelési tétel egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Az adott ételből mennyit rendeltek.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        /// <summary>
        /// A tételhez tartozó étel rendeléskori ára.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        /// <summary>
        /// A rendelés egyedi azonosítója, amihez a tétel tartozik.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Az étel egyedi azonosítója, amire a rendelési tétel vonatkozik.
        /// </summary>
        public int FoodId { get; set; }

        /// <summary>
        /// A rendelés, amihez a tétel tartozik.
        /// </summary>
        [Required]
        public Order Order { get; set; }


        /// <summary>
        /// Az étel, amire a rendelési tétel vonatkozik.
        /// </summary>
        [Required]
        public Food Food { get; set; }
    }
}
