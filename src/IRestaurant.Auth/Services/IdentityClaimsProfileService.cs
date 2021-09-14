using System.Collections.Generic;
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
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityClaimsProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

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

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
