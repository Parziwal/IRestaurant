using IRestaurant.DAL.DTO.Addresses;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az étterem szerkesztéséhez a kliens ebben a formátumban kell, hogy megadja az adatokat.
    /// </summary>
    public class EditRestaurantDto
    {
        /// <summary>
        /// Az étterem neve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Az étteremről egy rövidebb, pár mondatos ismertető.
        /// </summary>
        [Required]
        [StringLength(300)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Az étteremről egy részletesebb leírás.
        /// </summary>
        [StringLength(10000)]
        public string DetailedDescription { get; set; }

        /// <summary>
        /// Az étterem címe.
        /// </summary>
        [Required]
        public CreateOrEditAddressDto Address { get; set; }
    }
}
