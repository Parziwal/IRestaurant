using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadImage(IFormFile image, string folderName);
        void DeleteImage(string relativeImagePath);
    }
}
