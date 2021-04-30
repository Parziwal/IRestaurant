using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Foods
{
    public class CreateFoodDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
