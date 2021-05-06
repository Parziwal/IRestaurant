using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    /// <summary>
    /// A rendelési státuszokat tartalmazó enum osztály.
    /// </summary>
    public enum OrderStatus
    {
        //Feldolgozás alatt
        PROCESSING = 0,
        //Rendelés összeállítása
        ORDER_COMPLETION = 1,
        //Kiszállítás alatt
        UNDER_DELIVERING = 2,
        //Kiszállítva
        DELIVERED = 3,
        //Lemondva
        CANCELLED = 4
    }
}
