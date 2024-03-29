﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelés létrehozásához szükséges adatok követelményeit írja elő.
    /// </summary>
    public class CreateOrderDto
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
        public List<CreateOrderFoodDto> OrderFoods { get; set; } 
    }
}
