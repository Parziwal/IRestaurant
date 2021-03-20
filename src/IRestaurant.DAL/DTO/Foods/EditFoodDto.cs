using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Foods
{
    public class EditFoodDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
