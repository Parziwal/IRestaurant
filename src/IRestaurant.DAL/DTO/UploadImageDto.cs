using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileTypeChecker.Web.Attributes;

namespace IRestaurant.DAL.DTO
{
    public class UploadImageDto
    {
        [Required]
        [AllowImageOnly]
        public IFormFile ImageFile { get; set; }
    }
}
