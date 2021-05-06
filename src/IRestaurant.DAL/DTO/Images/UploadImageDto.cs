using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using FileTypeChecker.Web.Attributes;

namespace IRestaurant.DAL.DTO.Images
{
    /// <summary>
    /// A kép feltöltéséhez használt adatátviteli objektum.
    /// </summary>
    public class UploadImageDto
    {
        /// <summary>
        /// A képfájl.
        /// </summary>
        [Required]
        [AllowImageOnly]
        public IFormFile ImageFile { get; set; }
    }
}
