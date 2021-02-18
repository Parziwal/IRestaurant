using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string ShortDescription { get; set; }
        [StringLength(10000)]
        public string DetailedDescription { get; set; }
        public string ImagePath { get; set; }
        public RestaurantAddress Address { get; set; }
        [Required]
        public bool ShowForUsers { get; set; }
        [Required]
        public bool IsOrderAvailable { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public ICollection<Food> Foods { get; set; }
        public ICollection<FavouriteRestaurant> UsersFavourite { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
