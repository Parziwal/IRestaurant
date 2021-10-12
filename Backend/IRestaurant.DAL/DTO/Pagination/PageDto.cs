using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Pagination
{
    /// <summary>
    /// A lapozási adatokat tartalmazó osztály.
    /// </summary>
    public class PageDto
    {
        /// <summary>
        /// Az oldal száma.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Az oldal mérete.
        /// </summary>
        [Range(1, 50)]
        public int PageSize { get; set; } = 10;
    }
}
