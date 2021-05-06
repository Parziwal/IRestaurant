using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály az étteremekhez intézet rendeléseket tartalmazza.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// A rendelés egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A rendelés létrehozásának dátuma.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A felhasználó által megadott kívánt kiszállítási dátum.
        /// </summary>
        [Required]
        public DateTime PreferredDeliveryDate { get; set; }

        /// <summary>
        /// A rendelés státusza.
        /// </summary>
        [Required]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója, akihez a rendelés tartozik.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A felhasználó, akihez a rendelés tartozik.
        /// </summary>
        [Required]
        public ApplicationUser User { get; set; }


        /// <summary>
        /// A rendeléshez tartozó tételek listája.
        /// </summary>
        public ICollection<OrderFood> OrderFoods { get; set; }

        /// <summary>
        /// A rendeléshez tartozó számla.
        /// </summary>
        public Invoice Invoice { get; set; }
    }
}
