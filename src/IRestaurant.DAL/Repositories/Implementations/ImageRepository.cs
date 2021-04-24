using FileTypeChecker.Web.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private const string BaseImageFolder = "Images";
        public ImageRepository(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImage([AllowImageOnly] IFormFile image, string folderName)
        {
            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, BaseImageFolder, folderName);
            string uniqueFileName = Path.GetFileNameWithoutExtension(image.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string fullPath = Path.Combine(uploadFolder, uniqueFileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            string relativePath = Path.Combine(BaseImageFolder, folderName, uniqueFileName).Replace('\\', '/');
            return relativePath;
        }

        public void DeleteImage(string relativeImagePath)
        {
            string fullImagePath = Path.Combine(webHostEnvironment.WebRootPath, relativeImagePath == null ? "" : relativeImagePath);
            if (File.Exists(fullImagePath))
            {
                File.Delete(fullImagePath);
            }
        }
    }
}
