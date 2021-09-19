using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Foods
{
    /// <summary>
    /// Az ételek létrehozásához az adatokat ezen formátumban várjuk a klienstől.
    /// A szerkesztéshez képest itt megendedjük a név beállítását.
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
