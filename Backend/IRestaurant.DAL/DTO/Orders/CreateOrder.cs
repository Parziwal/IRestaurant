using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelés létrehozásához ezen osztálynak megfelelő formátumban várjuk az adatokat a klienstől.
    /// </summary>
    public class CreateOrder
    {
        /// <summary>
        /// A rendelés kívánt kiszállítási dátuma.
        /// </summary>
        [Required]
        public DateTime PreferredDeliveryDate { get; set; }

        /// <summary>
        /// A számlázási cím egyedi azonosítója, amit a rendelésnél magadtak.
        /// </summary>
        [Required]
        public int AddressId { get; set; }

        /// <summary>
        /// Az étterem egyedi azonosítója, ahonnét rendeltek.
        /// </summary>
        [Required]
        public int RestaurantId { get; set; }

        /// <summary>
        /// A rendeléshez tartozó tételek listája.
        /// </summary>
        [Required]
        public List<CreateOrderFood> OrderFoods { get; set; } 
    }
}
