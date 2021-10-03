using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// A rendeléshez kapcsolódó adatokon való műveletek elvégzéséért és az adatok lekéréséért felelős.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// A megadott vendéghez tartozó rendelések áttekintő adatainak lekérése a keresési feltétel alapján.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <param name="search">Az rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>A vendég rendeléseinek áttekintő adatai.</returns>
        Task<PagedListDto<OrderOverviewDto>> GetGuestOrderOverviewList(string guestId, OrderSearchDto search);

        /// <summary>
        /// A megadott étteremhez tartozó rendelések áttekintő adatainak lekérése a keresési feltétel alapján.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="search">Az rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>Az étterem rendeléseinek áttekintő adatai.</returns>
        Task<PagedListDto<OrderOverviewDto>> GetRestaurantOrderOverviewList(int restaurantId, OrderSearchDto search);

        /// <summary>
        /// A rendelés részletes adatainak lekérése.
        /// </summary>
        /// <param name="orderId">A rendelés azonosízója.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        Task<OrderDetailsDto> GetOrderDetails(int orderId);

        /// <summary>
        /// A megadott adatok alapján a rendelés létrehozása.
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója.</param>
        /// <param name="order">A rendelés adatait tartalmazó objektum.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        Task<OrderDetailsDto> CreateOrder(string userId, CreateOrder order);

        /// <summary>
        /// A rendelés státuszának módosítása.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <param name="status">A státusz, amire módosítjuk.</param>
        Task ChangeOrderStatus(int orderId, OrderStatus status);

        /// <summary>
        /// A rendeléshez tartozó felhasználói azonosító lekérése.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A felhasználó azonosítója.</returns>
        Task<string> GetOrderUserId(int orderId);

        /// <summary>
        /// Az étterem azonosítójának lekérdezése, amihez a rendelés tartozik.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>Az étterem azonosítója.</returns>
        Task<int> GetOrderRestaurantId(int orderId);

        /// <summary>
        /// A rendelés stétuszának lekérdezése.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A rendelés státusza.</returns>
        Task<OrderStatus> GetOrderStatus(int orderId);
    }
}
