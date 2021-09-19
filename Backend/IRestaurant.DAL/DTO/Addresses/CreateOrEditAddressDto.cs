using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Addresses
{
    /// <summary>
    /// A kliens ebben a formátumban adhatja meg a létrehozandó, vagy szerkesztendő címet.
    /// </summary>
    public class CreateOrEditAddressDto
    {
        /// <summary>
        /// Az irányítószám.
        /// </summary>
        [Required]
        [Range(1000, 9999)]
        public int ZipCode { get; set; }

        /// <summary>
        /// A város.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string City { get; set; }

        /// <summary>
        /// Az utca és házszám.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Street { get; set; }

        /// <summary>
        /// A címhez tartozó telefonos elérehtőség.
        /// </summary>
        [Required]
        [Phone]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }
    }
}
