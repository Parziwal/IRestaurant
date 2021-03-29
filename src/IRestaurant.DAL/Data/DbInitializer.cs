using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
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
        private static ApplicationDbContext _context;
        private static IServiceProvider _services;
        private static ApplicationUser[] users;
        public static async Task Initialize(ApplicationDbContext context, IServiceProvider services)
        {
            context.Database.EnsureCreated();

            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            if (context.Users.Any())
            {
                logger.LogInformation("The database was already seeded");
                return;
            }

            logger.LogInformation("Start seeding the database.");

            _context = context;
            _services = services;

            await CreateRoles();
            await CreateUsersWithAddress();
            await AddRoleToUsers();
            for (int i = 2;i < users.Length;i++)
            {
                await ConfigureUserRestaurant(users[i]);
                await AddReviewsToRestaurant(users[i].MyRestaurant);
            }
            
            logger.LogInformation("Finished seeding the database.");
        }

        private static async Task CreateRoles()
        {
            var roleManager = _services.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole("Guest"));
            await roleManager.CreateAsync(new IdentityRole("Restaurant"));
        }

        private static async Task CreateUsersWithAddress()
        {
            users = new ApplicationUser[]
                {
                    new ApplicationUser{ FullName="Carson Alexander", UserName="carson@email.hu", Email="carson@email.hu" },
                    new ApplicationUser{ FullName="Yan Li", UserName="yan@email.hu", Email="yan@email.hu"},
                    new ApplicationUser{ FullName="Peggy Justice", UserName="peggy@email.hu", Email="peggy@email.hu" },
                    new ApplicationUser{ FullName="Nini Olivetto", UserName="nini@email.hu", Email="nini@email.hu" },
                    new ApplicationUser{ FullName="Ayana Britt", UserName="ayana@email.hu", Email="ayana@email.hu" },
                    new ApplicationUser{ FullName="Kier Quintana", UserName="kier@email.hu", Email="kier@email.hu"},
                    new ApplicationUser{ FullName="Nazim Truong", UserName="nazim@email.hu", Email="nazim@email.hu" },
                    new ApplicationUser{ FullName="Alexandra Wang", UserName="alexandra@email.hu", Email="alexandra@email.hu" },
                };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            foreach (ApplicationUser user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Test.54321");
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();
            }

            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();

            var addresses = new List<UserAddress>();
            AddressOwned addressOwned = new AddressOwned
            {
                ZipCode = 1022,
                City = "Budapest",
                Street = "Lévay u. 5",
                PhoneNumber = "06-30-124-7898"
            };
            foreach(var user in users)
            {
                addresses.Add(new UserAddress {
                    User = user,
                    Address = addressOwned
                });
            }

            _context.UserAddresses.AddRange(addresses);
            await _context.SaveChangesAsync();
        }

        private static async Task AddRoleToUsers()
        {
            var userManager = _services.GetRequiredService<UserManager<ApplicationUser>>();
            for (int i = 0; i < users.Length; i++)
            {
                if (i > 1)
                {
                    await userManager.AddToRoleAsync(users[i], UserRoles.Restaurant);
                    continue;
                }
                await userManager.AddToRoleAsync(users[i], UserRoles.Guest);
            }
        }

        private static async Task ConfigureUserRestaurant(ApplicationUser user)
        {
            Random r = new Random();
            var dbRestaurant = new Restaurant
            {
                Name = "Lorem ipsum " + r.Next(),
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                "dolore magna aliqua. Et netus et malesuada fames ac. Imperdiet dui accumsan sit amet.",
                DetailedDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore" +
                " et dolore magna aliqua. Orci ac auctor augue mauris augue neque gravida. Nibh ipsum consequat nisl vel pretium lectus quam id" +
                " leo. Sapien eget mi proin sed libero enim sed. Fames ac turpis egestas integer eget aliquet. Etiam dignissim diam quis enim" +
                " lobortis scelerisque fermentum dui faucibus. Risus at ultrices mi tempus imperdiet nulla malesuada. Neque volutpat ac tincidunt" +
                " vitae semper quis lectus. Nisl vel pretium lectus quam id leo. Vulputate eu scelerisque felis imperdiet proin fermentum leo." +
                " Facilisis magna etiam tempor orci eu lobortis elementum nibh tellus. Congue nisi vitae suscipit tellus mauris a. Scelerisque" +
                " mauris pellentesque pulvinar pellentesque. Felis bibendum ut tristique et egestas. Non pulvinar neque laoreet suspendisse interdum." +
                " Tristique magna sit amet purus gravida. Turpis egestas pretium aenean pharetra magna ac placerat vestibulum. Ac tortor vitae purus" +
                " faucibus ornare suspendisse. Dui id ornare arcu odio ut sem nulla pharetra.Donec massa sapien faucibus et molestie ac feugiat sed" +
                " lectus.Vestibulum lectus mauris ultrices eros in cursus turpis massa.Velit aliquet sagittis id consectetur purus ut faucibus pulvinar." +
                "Auctor eu augue ut lectus arcu bibendum.Viverra tellus in hac habitasse platea dictumst.In metus vulputate eu scelerisque felis imperdiet proin" +
                " fermentum.Neque laoreet suspendisse interdum consectetur.Turpis tincidunt id aliquet risus feugiat.Lectus sit amet est placerat in egestas erat." +
                "Faucibus scelerisque eleifend donec pretium vulputate sapien nec.Mi quis hendrerit dolor magna eget est.Eget nulla facilisi etiam dignissim diam " +
                "quis enim lobortis.Habitant morbi tristique senectus et.Lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis.Lobortis scelerisque " +
                "fermentum dui faucibus in ornare quam viverra.Consectetur adipiscing elit pellentesque habitant morbi tristique.Cras adipiscing enim eu turpis egestas" +
                " pretium aenean pharetra magna.Id neque aliquam vestibulum morbi blandit cursus.Auctor augue mauris augue neque gravida in fermentum et sollicitudin. " +
                "Nullam ac tortor vitae purus faucibus ornare suspendisse sed nisi.Diam sit amet nisl suscipit adipiscing.Ultricies mi quis hendrerit" +
                " dolor magna eget est lorem.Nunc sed blandit libero volutpat sed.Nulla facilisi nullam vehicula ipsum a arcu cursus.At in tellus integer" +
                " feugiat scelerisque.Quis lectus nulla at volutpat diam ut venenatis tellus in. At quis risus sed vulputate.Tortor dignissim convallis" +
                " aenean et tortor at risus viverra adipiscing.Aliquam sem et tortor consequat id porta nibh venenatis cras.Viverra suspendisse potenti" +
                " nullam ac tortor.Mauris augue neque gravida in. Dignissim convallis aenean et tortor at risus.Quis viverra nibh cras pulvinar mattis" +
                " nunc.Suscipit adipiscing bibendum est ultricies integer quis auctor elit sed.",
                Address = new AddressOwned
                {
                    City = "Budapest",
                    ZipCode = 1048,
                    Street = "Jármultelep u. 3",
                    PhoneNumber = "06301234567"
                },
                ShowForUsers = true,
                IsOrderAvailable = true,
                Owner = user,
            };

            await _context.Restaurants.AddAsync(dbRestaurant);
            await _context.SaveChangesAsync();

            for (int i = 0; i < 15;i++)
            {
                var dbFood = new Food
                {
                    Name = "Nascetur ridiculus " + r.Next(),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et" +
                    " dolore magna aliqua. Nisi porta lorem mollis aliquam ut porttitor leo a diam. Quam lacus suspendisse faucibus interdum" +
                    " posuere lorem ipsum. Convallis a cras semper auctor neque. Arcu risus quis varius quam quisque id diam vel. In metus" +
                    " vulputate eu scelerisque felis imperdiet proin. Maecenas ultricies mi eget mauris. Pellentesque sit amet porttitor eget" +
                    " dolor. Vitae tortor condimentum lacinia quis vel eros donec ac odio. Ut etiam sit amet nisl purus in mollis nunc. Justo" +
                    " eget magna fermentum iaculis eu non.",
                    Price = r.Next(1000, 20000),
                    Restaurant = dbRestaurant
                };
                await _context.Foods.AddAsync(dbFood);
            }
            await _context.SaveChangesAsync();
        }

        private static async Task AddReviewsToRestaurant(Restaurant restaurant)
        {
            Random r = new Random();
            for (int i = 0; i < 2; i++)
            {
                var dbReview = new Review
                {
                    Title = "Vestibulum mattis ullamcorper velit",
                    Rating = r.NextDouble() * 4 + 1,
                    CreatedAt = DateTime.Now,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua. Sodales neque sodales ut etiam sit amet nisl. At " +
                    "erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Quam id leo in vitae turpis " +
                    "massa sed elementum tempus. Urna id volutpat lacus laoreet non curabitur. Risus nec feugiat in " +
                    "fermentum posuere urna nec. Mattis molestie a iaculis at erat pellentesque adipiscing commodo elit. " +
                    "Id diam vel quam elementum pulvinar etiam non. Egestas fringilla phasellus faucibus scelerisque eleifend " +
                    "donec pretium vulputate. Sed pulvinar proin gravida hendrerit lectus a. Tincidunt praesent semper feugiat " +
                    "nibh sed pulvinar proin gravida hendrerit. Habitant morbi tristique senectus et netus et malesuada. Mauris " +
                    "pharetra et ultrices neque ornare aenean euismod. Ac ut consequat semper viverra nam libero. Tempor id eu nisl " +
                    "nunc. Sed faucibus turpis in eu mi bibendum neque egestas.",
                    User = users[i],
                    Restaurant = restaurant
                };
                await _context.Reviews.AddAsync(dbReview);
            }
            await _context.SaveChangesAsync();
        }
    }
}
