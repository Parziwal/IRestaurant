using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Test.Extensions
{
    internal static class RepositoryTestExtensions
    {
        public static IReadOnlyList<Restaurant> SortBy(this IReadOnlyList<Restaurant> r, RestaurantSortBy sortBy)
        {
            switch (sortBy)
            {
                case RestaurantSortBy.NAME_ASC:
                    return new List<Restaurant>() { r[2], r[0], r[1] };
                case RestaurantSortBy.NAME_DESC:
                    return new List<Restaurant>() { r[1], r[0], r[2] };
                case RestaurantSortBy.RATING_ASC:
                    return new List<Restaurant>() { r[2], r[1], r[0] };
                case RestaurantSortBy.RATING_DESC:
                    return new List<Restaurant>() { r[0], r[1], r[2] };
                case RestaurantSortBy.REVIEW_COUNT_ASC:
                    return new List<Restaurant>() { r[2], r[1], r[0] };
                case RestaurantSortBy.REVIEW_COUNT_DESC:
                    return new List<Restaurant>() { r[0], r[1], r[2] };
                default:
                    return r;
            }
        }

        public static IReadOnlyList<Restaurant> SortByCarsonFavourite(this IReadOnlyList<Restaurant> r, RestaurantSortBy sortBy)
        {
            switch (sortBy)
            {
                case RestaurantSortBy.NAME_ASC:
                    return new List<Restaurant>() { r[0], r[1] };
                case RestaurantSortBy.NAME_DESC:
                    return new List<Restaurant>() { r[1], r[0] };
                case RestaurantSortBy.RATING_ASC:
                    return new List<Restaurant>() { r[1], r[0] };
                case RestaurantSortBy.RATING_DESC:
                    return new List<Restaurant>() { r[0], r[1] };
                case RestaurantSortBy.REVIEW_COUNT_ASC:
                    return new List<Restaurant>() { r[1], r[0] };
                case RestaurantSortBy.REVIEW_COUNT_DESC:
                    return new List<Restaurant>() { r[0], r[1] };
                default:
                    return r;
            }
        }
    }
}
