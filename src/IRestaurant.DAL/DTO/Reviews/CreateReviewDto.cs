using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
