﻿using IdentityModel;
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

namespace IRestaurant.BL
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> mUserManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            mUserManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            ApplicationUser user = await mUserManager.GetUserAsync(context.Subject);

            IList<string> roles = await mUserManager.GetRolesAsync(user);

            IList<Claim> roleClaims = new List<Claim>();
            foreach (string role in roles)
            {
                roleClaims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            context.IssuedClaims.AddRange(roleClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
