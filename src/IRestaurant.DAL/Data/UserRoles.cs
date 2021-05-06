using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Data
{
    /// <summary>
    /// A felhasználói szerepköröket tartalmazó osztály.
    /// </summary>
    public static class UserRoles
    {
        /// <summary>
        /// Étterem szerepkör.
        /// </summary>
        public const string Restaurant = "Restaurant";

        /// <summary>
        /// Vendég szerepkör.
        /// </summary>
        public const string Guest = "Guest";
    }
}
