using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public enum OrderStatus
    {
        PROCESSING = 0,
        ORDER_COMPLETION = 1,
        UNDER_DELIVERING = 2,
        DELIVERED = 3,
        CANCELLED = 4
    }
}
