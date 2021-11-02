using Hellang.Middleware.ProblemDetails;
using IRestaurant.BL.Extensions;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BL.Managers
{
    /// <summary>
    /// A rendelések lekérdezésével, létrehozásával és státuszuk módosításával kapcsolatos műveletek
    /// irányelveinek kikényszerítéséért felelős.
    /// </summary>
    public class OrderManager
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IHttpContextAccessor httpContext;
        private const int MIN_HOUR_AFTER_ORDER = 1;

        public OrderManager(IOrderRepository orderRepository,
            IUserRepository userRepository,
            IRestaurantRepository restaurantRepository,
            IHttpContextAccessor httpContext)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.restaurantRepository = restaurantRepository;
            this.httpContext = httpContext;
        }

        /// <summary>
        /// Az aktuális vendéghez tartozó rendelések áttekintő adatainak lekérdezése a keresési feltétel alapján.
        /// </summary>
        /// <param name="search">A rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>A bejelentkezett vendég rendelési.</returns>
        public async Task<PagedListDto<OrderOverviewDto>> GetGuestOrderOverviewList(OrderSearchDto search)
        {
            string userId = httpContext.GetCurrentUserId();
            return await orderRepository.GetGuestOrderOverviewList(userId, search);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étteremhez leadott rendelések áttekintő adatainak
        /// lekérdezése a keresési feltétel alapján.
        /// </summary>
        /// <param name="search">A rendelésre vonatkozó keresési feltétel.</param>
        /// <returns>Az étteremhez beérkező rendelések.</returns>
        public async Task<PagedListDto<OrderOverviewDto>> GetMyRestaurantOrderOverviewList(OrderSearchDto search)
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await orderRepository.GetRestaurantOrderOverviewList(ownerRestaurantId, search);
        }

        /// <summary>
        /// A megadott azonosítójú rendelés részletes adatainak lekérdezése, ha
        /// a rendelés az aktuális felhasználóhoz, vagy az aktuális felhasználó étterméhez tartozik.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <returns>A rendelés részletes adatai.</returns>
        public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
        {
            string userId = httpContext.GetCurrentUserId();
            string orderUserId = await orderRepository.GetOrderUserId(orderId);
            int userRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;
            int orderRestaurantId = await orderRepository.GetOrderRestaurantId(orderId);

            if (userId == orderUserId || userRestaurantId == orderRestaurantId)
            {
                return await orderRepository.GetOrderDetails(orderId);
            }
            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés megtekintéséhez nincs jogosultságod");
        }

        /// <summary>
        /// A paraméterül kapott rendelés létrehozása, ha a kívánt kiszállítási idő minimum a megadott
        /// idővel a rendelés leadása után van és a rendelési opció is be van kapcsolva az étteremnél.
        /// </summary>
        /// <param name="order">A létrehozandó rendelés adatai.</param>
        /// <returns>A létrehozott rendelés részletei.</returns>
        public async Task<OrderDetailsDto> CreateOrder(CreateOrder order)
        {
            if (order.PreferredDeliveryDate < new DateTime().AddHours(MIN_HOUR_AFTER_ORDER))
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    $"A kívánt kiszállítási időnek minimum {MIN_HOUR_AFTER_ORDER} órával a rendelés leadása után kell lennie.");
            }

            var restaurantSettings = await restaurantRepository.GetRestaurantSettings(order.RestaurantId);
            if (!restaurantSettings.IsOrderAvailable)
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott étteremnél a rendelési lehetőség jelenleg nem elérhető.");
            }

            string userId = httpContext.GetCurrentUserId();
            return await orderRepository.CreateOrder(userId, order);
        }

        /// <summary>
        /// A megadott rendelés státuszának módosítása.
        /// Ez akkor lehetséges, ha a rendelés az aktuális felhasználóhoz tartozik és még feldolgozási állapotban szeretnénk lemondani;
        /// vagy ha a rendelés az aktuális éttremhez tartozik és egy következő státuszba szeretnék mozgatni.
        /// Ha az étterem vissza akarja mondani a rendelést, akkor azt a kiszállítva státusz előtt teheti meg.
        /// </summary>
        /// <param name="orderId">A rendelés azonosítója.</param>
        /// <param name="status">A beállítandó státusz.</param>
        public async Task ChangeOrderStatus(int orderId, OrderStatus status)
        {
            OrderStatus orderStatus = await orderRepository.GetOrderStatus(orderId);
            string userId = httpContext.GetCurrentUserId();
            string orderUserId = await orderRepository.GetOrderUserId(orderId);

            if (userId == orderUserId
                && status == OrderStatus.CANCELLED
                && orderStatus == OrderStatus.PROCESSING)
            {
                await orderRepository.ChangeOrderStatus(orderId, status);
                return;
            }

            int userRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;
            int orderRestaurantId = await orderRepository.GetOrderRestaurantId(orderId);
            if (userRestaurantId == orderRestaurantId
                && orderStatus < status
                && orderStatus != OrderStatus.DELIVERED)
            {
                await orderRepository.ChangeOrderStatus(orderId, status);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező rendelés státuszának megváltoztatásához nincs jogosultságod," +
                "vagy egy korábbi állapotba való visszaálítása nem lehetséges.");
        }
    }
}
