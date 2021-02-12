using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public enum Status
    {
        [Description("Feldolgozás alatt")]
        PROCESSING,
        [Description("Rendelés összeállítása")]
        ORDER_COMPLETION,
        [Description("Kiszállítás alatt")]
        UNDER_DELIVERING,
        [Description("Kiszállítva")]
        DELIVERED,
        [Description("Lemondva")]
        CANCELLED
    }
}
