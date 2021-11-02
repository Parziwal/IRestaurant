using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.DTO.Pagination;
using IRestaurant.DAL.DTO.Restaurants;
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
    internal static class RestaurantRepositoryExtensions
    {
        /// <summary>
        /// A étterem típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="restaurants">Étterem típusú lekérdezés.</param>
        /// <param name="page">Lapozási adatokat tartalmazó ozstály.</param>
        /// <returns>Áttekintő étterem adatokat tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<PagedListDto<RestaurantOverviewDto>> ToRestaurantOverviewDtoPagedList(this IQueryable<Restaurant> restaurants, PageDto page)
        {
            var pagedList = await restaurants
                            .Include(r => r.Reviews)
                            .Select(r => new RestaurantOverviewDto(r))
                            .ToPagedListAsync(page.PageNumber, page.PageSize);
            return new PagedListDto<RestaurantOverviewDto>(pagedList);
        }

        /// <summary>
        /// A lekérdezésre alkalmazza a megadott rendezési szempontot.
        /// </summary>
        /// <param name="restaurants">Étterem típusú lekérdezés.</param>
        /// <param name="sortBy">A rendezési szempont.</param>
        /// <returns>Étterem típusú lekérdezés.</returns>
        public static IQueryable<Restaurant> SortBy(this IQueryable<Restaurant> restaurants, string sortBy)
        {
            Enum.TryParse(sortBy, true, out RestaurantSortBy restaurantSortBy);
            switch (restaurantSortBy)
            {
                case RestaurantSortBy.NAME_ASC:
                    return restaurants.OrderBy(r => r.Name);
                case RestaurantSortBy.NAME_DESC:
                    return restaurants.OrderByDescending(r => r.Name);
                case RestaurantSortBy.RATING_ASC:
                    return restaurants.OrderBy(r => 
                        r.Reviews.Any() ? Math.Round(r.Reviews.Average(r => r.Rating), 2) : 0);
                case RestaurantSortBy.RATING_DESC:
                    return restaurants.OrderByDescending(r =>
                        r.Reviews.Any() ? Math.Round(r.Reviews.Average(r => r.Rating), 2) : 0);
                case RestaurantSortBy.REVIEW_COUNT_ASC:
                    return restaurants.OrderBy(r => r.Reviews.Count);
                case RestaurantSortBy.REVIEW_COUNT_DESC:
                    return restaurants.OrderByDescending(r => r.Reviews.Count);
                default:
                    return restaurants;
            }
        }

        /// <summary>
        /// Az étterem modell osztály átalakítása részletes adatokat tartalmazó adatátviteli objektummá.
        /// </summary>
        /// <param name="restaurant">Étterem típusú entitás.</param>
        /// <returns>Az étterem részletes adatait tartalmazó adatátviteli objektum.</returns>
        public static async Task<RestaurantDetailsDto> ToRestaurantDetailsDto(this EntityEntry<Restaurant> restaurant)
        {
            await restaurant.Collection(r => r.Reviews).LoadAsync();
            await restaurant.Reference(r => r.Owner).LoadAsync();
            return new RestaurantDetailsDto(restaurant.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott étterem típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="restaurant">Étterem típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Étterem típusú modell osztály.</returns>
        public static Restaurant CheckIfRestaurantNull(this Restaurant restaurant,
            string errorMessage = "Az étterem nem található.")
        {
            if (restaurant == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return restaurant;
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott kedvenc éttermet tartalamzó modell osztáy null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="favouriteRestaurant">A vendég egyik kedvenc éttermét tartalmazó modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>A vendég egyik kedvenc éttermét tartalmazó modell osztály.</returns>
        public static FavouriteRestaurant CheckIfFavouriteRestaurantNull(this FavouriteRestaurant favouriteRestaurant,
            string errorMessage = "A felhasználó kedvenc étterme nem található.")
        {
            if (favouriteRestaurant == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return favouriteRestaurant;
        }
    }
}
