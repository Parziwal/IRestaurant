using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztály jelképezi a felhasználót.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// A felhasználó vezeték és keresztneve.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        /// <summary>
        /// A vendég szerepkörrel renndelkező felhasználó lakcímei.
        /// </summary>
        public ICollection<UserAddress> UserAddresses { get; set; }

        /// <summary>
        /// Az étterem szerepkörrel rendelkező felhasználó étterme.
        /// </summary>
        public Restaurant MyRestaurant { get; set; }

        /// <summary>
        /// A vendég szerepkörrel rendelkező felhasználó kedvenc éttermei.
        /// </summary>
        public ICollection<FavouriteRestaurant> FavouriteRestaurants { get; set; }

        /// <summary>
        /// A vendég szerepkörrel rendelkező felhasználó értékelései.
        /// </summary>
        public ICollection<Review> Reviews { get; set; }

        /// <summary>
        /// A vendég szerepkörrel rendelkező felhasználó rendelései.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}
