using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Foods
{
    /// <summary>
    /// Az étel kétrehozásához szükséges adatok követelményeit írja elő.
    /// </summary>
    public class CreateFoodDto : EditFoodDto
    {
        /// <summary>
        /// Az étel neve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
