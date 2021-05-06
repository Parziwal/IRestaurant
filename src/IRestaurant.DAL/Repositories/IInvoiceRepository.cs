using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// A rendelésekhez kapcsolódó számla adatok létrehozásáért felelős.
    /// </summary>
    public interface IInvoiceRepository
    {
        /// <summary>
        /// A megadott paraméterek alapján a rendeléshez tartozó számla létrehozása.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <param name="userAddressId">A felhasználó által megadott számlázási cím azonosítója.</param>
        /// <param name="restaurantId">Az étterem azonosítója, ahonnét rendeltek.</param>
        /// <returns>A létrehozott számla.</returns>
        Task<Invoice> CreateInvoice(int orderId, int userAddressId, int restaurantId);
    }
}
