using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Food
{
    public class EditFoodDto
    {
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
