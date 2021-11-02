using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Auth.Services
{
    /// <summary>
    /// Az email kulcs megszerzéséért felelős osztály.
    /// </summary>
    public class AuthMessageSenderOptions
    {
        /// <summary>
        /// Send Grid email küldős szolgáltatás API kulcsa.
        /// </summary>
        public string SendGridKey { get; set; }
    }
}
