using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        public ICollection<UserAddress> Addresses { get; set; }
        public Restaurant MyRestaurant { get; set; }
        public ICollection<FavouriteRestaurant> FavouriteRestaurants { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
