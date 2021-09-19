using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály a rendelésekhez tartozó számlát jelképezi.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// A számla egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A felhasználó vezeták és keresztneve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserFullName { get; set; }

        /// <summary>
        /// A felhasználó rendeléskor megadott számlázási címe.
        /// </summary>
        [Required]
        public AddressOwned UserAddress { get; set; }

        /// <summary>
        /// Az étterem neve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string RestaurantName { get; set; }

        /// <summary>
        /// Az étteremhez tartozó számlázási cím.
        /// </summary>
        [Required]
        public AddressOwned RestaurantAddress { get; set; }

        /// <summary>
        /// A rendelés egyedi azonosítója, amihez a számla tartozik.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// A rendelés, amihez a számla tartozik.
        /// </summary>
        [Required]
        public Order Order { get; set; }
    }
}
