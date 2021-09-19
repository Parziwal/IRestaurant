using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Foods
{
    /// <summary>
    /// Az ételek szerkesztéséhez az adatokat ezen formátumban várjuk a klienstől.
    /// </summary>
    public class EditFoodDto
    {
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
    }
}
