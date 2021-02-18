using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class CreateReview
    {
        [Range(1, 5)]
        public int Rating { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(10000)]
        public string Description { get; set; }
    }
}
