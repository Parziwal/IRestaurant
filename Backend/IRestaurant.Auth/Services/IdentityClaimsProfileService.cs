﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Infrastructure.Services
{
    /// <summary>
    /// A felhasználó fontosabb adatainak tokenbe helyezéséért felelős.
    /// </summary>
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Az tagváltó inicializációja.
        /// </summary>
        /// <param name="userManager">A felhasználó kezeléshez biztosít egy API-kat.</param>
        public IdentityClaimsProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// A felhasználó fontosabb adatainak meghatározása, amit majd a tokenbe fogunk helyezni.
        /// </summary>
        /// <param name="context">A felhasználó claim-jeinek lekérése.</param>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            IList<string> roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtClaimTypes.Name, user.FullName));
            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
            
            foreach (string role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            context.IssuedClaims.AddRange(claims);
        }

        /// <summary>
        /// Jelzi, hogy a felhasználó engedélyezett-e a token elkérésére.
        /// </summary>
        /// <param name="context">Megállapítja, hogy a felhasználó elkérheti-e a tokent.</param>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
