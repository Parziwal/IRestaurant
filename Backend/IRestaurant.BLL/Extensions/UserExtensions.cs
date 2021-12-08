using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BLL.Extensions
{
    internal static class UserExtensions
    {
        /// <summary>
        ///  A jelenleg bejelentkezett felhasználó egyedi azonosítóját adja meg.
        /// </summary>
        /// <param name="httpContext">A HttpContext-hez biztosít hozzáférést.</param>
        /// <returns>Az aktuális felhasználó egyedi azonosítója.</returns>
        public static string GetCurrentUserId(this IHttpContextAccessor httpContext)
        {
            return httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                        httpContext.HttpContext.User.FindFirstValue("sub");
        }
    }
}
