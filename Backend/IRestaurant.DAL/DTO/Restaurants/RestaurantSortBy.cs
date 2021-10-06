using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Restaurants
{
    /// <summary>
    /// Az éttermek lehetséges rendezési sorrendjei.
    /// </summary>
    public enum RestaurantSortBy
    {
        NAME_ASC, NAME_DESC,
        RATING_ASC, RATING_DESC,
        REVIEW_COUNT_ASC, REVIEW_COUNT_DESC
    }
}
