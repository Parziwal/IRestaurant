using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Reviews
{
    public class ReviewDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(10000)]
        public string Description { get; set; }
        public string UserFullName { get; set; }

        public ReviewDto(Models.Review review, Models.ApplicationUser user)
        {
            this.Id = review.Id;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.Description = review.Description;
            this.UserFullName = user.FullName;
        }
    }
}
