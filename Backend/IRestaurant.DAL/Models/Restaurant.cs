using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// Ez a modell osztályaz éttermeket reprezentálja.
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// Az étterem egyedi azonosítója.
        /// </summary>
        public int Id { get; set; }

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
        /// Az étteremhez tartozó kép elérési útja.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Az étterem címe.
        /// </summary>
        public AddressOwned Address { get; set; }

        /// <summary>
        /// Az étterem elérhető-e a felhasználók számára.
        /// </summary>
        [Required]
        public bool ShowForUsers { get; set; }

        /// <summary>
        /// Az étteremtől lehet-e rendelni, tehát a rendelési opció engedélyezve van-e.
        /// </summary>
        [Required]
        public bool IsOrderAvailable { get; set; }

        /// <summary>
        /// Az étterem tulajdonosának egyedi azonosítója.
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Az étterem tulajdonosa.
        /// </summary>
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// Az étteremhez tartozó ételek listája.
        /// </summary>
        public ICollection<Food> Foods { get; set; }

        /// <summary>
        /// Azon felhasználók listáját tartalmazza, akik az éttermet kedvencüknek jelölték.
        /// </summary>
        public ICollection<FavouriteRestaurant> UsersFavourite { get; set; }

        /// <summary>
        /// Az étteremhez tartozó értékelések listája.
        /// </summary>
        public ICollection<Review> Reviews { get; set; }
    }
}
