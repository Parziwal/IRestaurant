using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A lakcím létrehozásához és szerkesztéséhez szükséges adatok követelményeit írja elő.
    /// </summary>
    public class CreateOrEditAddressDto
    {
        /// <summary>
        /// Az irányítószám.
        /// </summary>
        [Required(ErrorMessage = "Az irányítószám megadása kötelező.")]
        [Range(1000, 9999, ErrorMessage = "A irányítószámnak 4 számjegyből kell állnia.")]
        public int ZipCode { get; set; }

        /// <summary>
        /// A város.
        /// </summary>
        [Required(ErrorMessage = "Az város megadása kötelező.")]
        [StringLength(100, ErrorMessage = "A város maximum {1} karakter hosszú lehet.")]
        public string City { get; set; }

        /// <summary>
        /// Az utca és házszám.
        /// </summary>
        [Required(ErrorMessage = "Az utca megadása kötelező.")]
        [StringLength(200, ErrorMessage = "Az utca maximum {1} karakter hosszú lehet.")]
        public string Street { get; set; }

        /// <summary>
        /// A címhez tartozó telefonos elérehtőség.
        /// </summary>
        [Required(ErrorMessage = "Az telefonszám megadása kötelező.")]
        [Phone(ErrorMessage = "A telefonszámnak jól formázottnak kell lennie.")]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Kérlek az alábbi formátumban add meg a telefonszámot: 06-30-125-6789")]
        public string PhoneNumber { get; set; }
    }
}
