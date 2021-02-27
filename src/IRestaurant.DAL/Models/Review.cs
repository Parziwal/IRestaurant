using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [StringLength(10000)]
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public string UserId { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
    }
}
