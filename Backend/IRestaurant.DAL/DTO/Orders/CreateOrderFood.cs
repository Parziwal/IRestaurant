using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendeléshez tarozó tételek létrehozásához szükséges adatok követelményeit írja elő.
    /// </summary>
    public class CreateOrderFood
    {
        /// <summary>
        /// Az étel egyedi azonosítója.
        /// </summary>
        [Required]
        public int FoodId { get; set; }

        /// <summary>
        /// A rendelési mennyiség.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
