using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Foods
{
    public class CreateFoodDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
