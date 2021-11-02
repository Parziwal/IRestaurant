using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// A lakcím információkat tartalmazó owned típusú osztály.
    /// </summary>
    [Owned]
    public class AddressOwned
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
        /// Az utca, illetve házszám.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Street { get; set; }

        /// <summary>
        /// A címhez tartozó telefonos elérhetőség.
        /// </summary>
        [Required]
        [Phone]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }
    }
}
