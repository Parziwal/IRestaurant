using System;
using System.ComponentModel.DataAnnotations;

namespace IRestaurant.DAL.DTO.Reviews
{
    public class CreateReviewDto
    {
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(10000)]
        public string Description { get; set; }
    }
}
