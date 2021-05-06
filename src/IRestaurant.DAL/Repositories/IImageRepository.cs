using FileTypeChecker.Web.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// A képkezelésért felelős osztály, ami biztosítja a képek feltöltését a megadott könyvtárban, illetve azok törlését.
    /// </summary>
    public interface IImageRepository
    {
        /// <summary>
        /// A képfájl feltöltése a megadott könyvtárba.
        /// </summary>
        /// <param name="image">A képfájl.</param>
        /// <param name="folderName">A könyvtár neve.</param>
        /// <returns>A kép relatív elérési útja.</returns>
        Task<string> UploadImage([AllowImageOnly] IFormFile image, string folderName);

        /// <summary>
        /// Az elérési útvonalon lévő kép törlése.
        /// </summary>
        /// <param name="relativeImagePath"></param>
        void DeleteImage(string relativeImagePath);
    }
}
