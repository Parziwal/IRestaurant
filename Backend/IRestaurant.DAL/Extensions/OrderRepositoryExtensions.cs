using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.DTO.Orders;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace IRestaurant.DAL.Extensions
{
    /// <summary>
    /// Az rendeléshez kapcsolódó extension metódusok.
    /// </summary>
    internal static class OrderRepositoryExtensions
    {
        /// <summary>
        /// A rendelés típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="orders">Rendelés típusú lekérdezés.</param>
        /// <param name="page">Lapozási adatokat tartalmazó ozstály.</param>
        /// <returns>Áttekintő rendelési adatokat tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<PagedListDto<OrderOverviewDto>> ToOrderOverviewDtoPagedList(this IQueryable<Order> orders, PageDto page)
        {
            var pagedList = await orders
                                .Include(o => o.OrderFoods)
                                .Include(o => o.Invoice)
                                .Select(o => new OrderOverviewDto(o))
                                .ToPagedListAsync(page.PageNumber, page.PageSize);
            return new PagedListDto<OrderOverviewDto>(pagedList);
        }

        /// <summary>
        /// A lekérdezésre alkalmazza a megadott rendezési szempontot.
        /// </summary>
        /// <param name="orders">Rendelés típusú lekérdezés.</param>
        /// <param name="sortBy">A rendezési szempont.</param>
        /// <returns>Rendelés típusú lekérdezés.</returns>
        public static IQueryable<Order> SortBy(this IQueryable<Order> orders, string sortBy)
        {
            Enum.TryParse(sortBy, true, out OrderSortBy orderSortBy);
            switch (orderSortBy)
            {
                case OrderSortBy.CREATED_AT_ASC:
                    return orders.OrderBy(o => o.CreatedAt);
                case OrderSortBy.CREATED_AT_DESC:
                    return orders.OrderByDescending(o => o.CreatedAt);
                case OrderSortBy.PREFFERED_DELIVERY_DATE_ASC:
                    return orders.OrderBy(o => o.PreferredDeliveryDate);
                case OrderSortBy.PREFFERED_DELIVERY_DATE_DESC:
                    return orders.OrderByDescending(o => o.PreferredDeliveryDate);
                default:
                    return orders;
            }
        }

        /// <summary>
        /// A rendelés modell osztály átalakítása részletes adatokat tartalmazó adatátviteli objektummá.
        /// </summary>
        /// <param name="order">Rendelés típusú entitás.</param>
        /// <returns>A rendelés részletes adatait tartalmazó adatátviteli objektum.</returns>
        public static async Task<OrderDetailsDto> ToOrderDetailsDto(this EntityEntry<Order> order)
        {
            await order.Reference(o => o.Invoice).LoadAsync();
            await order.Collection(o => o.OrderFoods).Query()
                        .Include(of => of.Food).LoadAsync();
            return new OrderDetailsDto(order.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott rendelés típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="order">Rendelés típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Rendelés típusú modell osztály.</returns>
        public static Order CheckIfOrderNull(this Order order,
            string errorMessage = "A rendelés nem található.")
        {
            if (order == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return order;
        }
    }
}
