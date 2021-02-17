using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, IServiceProvider services)
        {
            context.Database.EnsureCreated();

            var logger = services.GetRequiredService<ILogger<DbInitializer>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            if (context.Users.Any())
            {
                logger.LogInformation("The database was already seeded");
                return;
            }

            logger.LogInformation("Start seeding the database.");
            
            await roleManager.CreateAsync(new IdentityRole("Guest"));
            await roleManager.CreateAsync(new IdentityRole("Restaurant"));

            var users = new ApplicationUser[]
                {
                    new ApplicationUser{UserName="alexander33", FullName="Carson Alexander", Email="carson@email.hu"},
                    new ApplicationUser{UserName="yanli99", FullName="Yan Li", Email="yan@email.hu"},
                    new ApplicationUser{UserName="peggy95", FullName="Peggy Justice", Email="peggy@email.hu"},
                    new ApplicationUser{UserName="nini45",FullName="Nini Olivetto", Email="nini@email.hu"},
                };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            foreach (ApplicationUser user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Test.54321");
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();
                await userManager.AddToRoleAsync(user, "Guest");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            logger.LogInformation("Finished seeding the database.");
        }
    }
}
