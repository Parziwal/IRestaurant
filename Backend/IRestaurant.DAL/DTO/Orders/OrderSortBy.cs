using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Orders
{
    /// <summary>
    /// A rendelések lehetséges rendezési sorrendjei.
    /// </summary>
    public enum OrderSortBy
    {
        CREATED_AT_ASC, CREATED_AT_DESC,
        PREFFERED_DELIVERY_DATE_ASC, PREFFERED_DELIVERY_DATE_DESC,
        RESTAURANT_NAME_ASC, RESTAURANT_NAME_DESC,
        USER_NAME_ASC, USER_NAME_DESC
    }
}
