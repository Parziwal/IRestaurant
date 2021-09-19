using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály reprezentálja a felhasználókhoz tartozó címeket.
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// A cím egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// A cím információkat tartalmazó típus.
        /// </summary>
        public AddressOwned Address { get; set; }

        /// <summary>
        /// A felhasználó egyedi azonosítója, akihez a cím tartozik.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A felhasználó, akihez a cím tartozik.
        /// </summary>
        [Required]
        public ApplicationUser User { get; set; }
    }
}
