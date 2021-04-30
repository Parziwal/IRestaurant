using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using FileTypeChecker.Web.Attributes;

namespace IRestaurant.DAL.DTO.Images
{
    public class UploadImageDto
    {
        [Required]
        [AllowImageOnly]
        public IFormFile ImageFile { get; set; }
    }
}
