using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Orders
{
    public class CreateOrderFood
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
