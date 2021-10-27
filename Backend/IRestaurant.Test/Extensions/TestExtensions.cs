using IdentityModel.Client;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IRestaurant.Test.Extensions
{
    internal static class TestExtensions
    {
        public static IReadOnlyList<Restaurant> SortByAll(this IReadOnlyList<Restaurant> r, RestaurantSortBy sortBy)
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

        public static string ToQueryParams(this Object o)
        {
            var query = o.GetType().GetProperties()
               .Where(s => s.GetValue(o, null) != null)
               .Select(s => s.Name + "=" + HttpUtility.UrlEncode(s.GetValue(o, null).ToString()));

            return String.Join("&", query.ToArray());
        }

        public static async Task<string> GetAccessToken(this TestServer authServer, string userName, string password)
        {
            var authClient = authServer.CreateClient();
            var discovery = await authClient.GetDiscoveryDocumentAsync();
            var response = await authClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = discovery.TokenEndpoint,
                ClientId = "irestaurant_test",
                Scope = "openid profile email irestaurant.api",
                UserName = userName,
                Password = password
            });

            if (response.HttpStatusCode != HttpStatusCode.OK) return null;

            return response.AccessToken;
        }
    }
}
