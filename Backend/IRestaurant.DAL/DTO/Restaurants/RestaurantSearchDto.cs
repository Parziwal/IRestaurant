using IRestaurant.DAL.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// A étteremre vonatkozó keresési feltételeket tartalmazó osztály.
    /// </summary>
    public class RestaurantSearchDto : PageDto
    {
        /// <summary>
        /// Az étterem nevében, ismertetőjében, vagy a város nevében tartalmazandó kifejezés.
        /// </summary>
        public string NameOrShortDescriptionOrCity { get; set; } = "";

        /// <summary>
        /// Az étteremre vonatkozó keresési feltételeket tartalmazó osztály.
        /// </summary>
        public string SortBy { get; set; } = RestaurantSortBy.NAME_ASC.ToString();
    }
}
