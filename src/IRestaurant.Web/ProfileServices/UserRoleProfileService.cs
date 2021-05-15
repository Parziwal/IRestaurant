using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Web.ProfileServices
{
    /// <summary>
    /// A felhasználói szerepkörök tokenbe helyezéséért felelős.
    /// </summary>
    public class UserRoleProfileService : IProfileService
    {
        private UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Az tagváltó inicializációja.
        /// </summary>
        /// <param name="userManager">A felhasználó kezeléshez biztosít egy API-kat.</param>
        public UserRoleProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// A felhasználó szerepköreinek meghatározása, amit majd a tokenbe fogunk helyezni.
        /// </summary>
        /// <param name="context">A felhasználó claim-jeinek lekérése.</param>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            ApplicationUser user = await userManager.GetUserAsync(context.Subject);

            IList<string> roles = await userManager.GetRolesAsync(user);

            IList<Claim> roleClaims = new List<Claim>();
            foreach (string role in roles)
            {
                roleClaims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            context.IssuedClaims.AddRange(roleClaims);
        }

        /// <summary>
        /// Jelzi, hogy a felhasználó engedélyezett-e a token elkérésére.
        /// </summary>
        /// <param name="context">Megállapítja, hogy a felhasználó elkérheti-e a tokent.</param>
        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
