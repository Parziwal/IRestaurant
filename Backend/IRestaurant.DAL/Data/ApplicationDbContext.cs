using IdentityServer4.EntityFramework.Options;
using IRestaurant.DAL.Data.EntityTypeConfigurations;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Data
{
    /// <summary>
    /// Az adatbázist reprezentáló osztály. Egy hidat képez az entitás osztályok és az adatbázis között,
    /// ő felelős az adatbázissal való interakcióért.
    /// </summary>
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        /// <summary>
        /// A felhasználói címeket tartalamzó tábla.
        /// </summary>
        public DbSet<UserAddress> UserAddresses { get; set; }

        /// <summary>
        /// Az ételeket tartalamzó tábla.
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        /// <summary>
        /// A rendeléseket tartalmazó tábla.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// A rendelési tételeket tartalmazó tábla.
        /// </summary>
        public DbSet<OrderFood> OrderFoods { get; set; }

        /// <summary>
        /// Az étteremeket tartalmazó tábla.
        /// </summary>
        public DbSet<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Az értékeléseket tartalmazó tábla.
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// A számlákat tartalmazó tábla.
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// A felhasználók kedvenc éttermeit tartalmazó tábla.
        /// </summary>
        public DbSet<FavouriteRestaurant> FavouriteRestaurants { get; set; }

        private ApplicationSeedData seedData;

        /// <summary>
        /// Az adatbázishoz szükséges beállítási adatok elkérése.
        /// </summary>
        /// <param name="options">DbContext által használandó opciók.</param>
        /// <param name="operationalStoreOptions">Konfigurált példányok lekérésére szolgál.</param>
        /// <param name="seedData">Az adatbázist inicializáló adatokat tartalmazza.</param>
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ApplicationSeedData seedData) : base(options, operationalStoreOptions)
        {
            this.seedData = seedData;
        }

        /// <summary>
        /// Az entitás osztályok konfigurálása.
        /// </summary>
        /// <param name="modelBuilder">Definiálja az entitásokat, közöttük lévő kapcsolatokat, és azt, hogy miként térképezik fel az adatbázist.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //A táblák nevének beállítása
            modelBuilder.Entity<UserAddress>().ToTable("UserAddress");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderFood>().ToTable("OrderFood");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<FavouriteRestaurant>().ToTable("FavouriteRestaurant");

            //Query filter beállítása a Food modellen a "soft delete" funkció megvalósítása miatt.
            modelBuilder.Entity<Food>().HasMany(f => f.OrderFoods).WithOne(of => of.Food).IsRequired(false);
            modelBuilder.Entity<Food>().HasQueryFilter(e => !e.IsDeleted);

            /// Az adatbázis feltöltése adatokkal.
            modelBuilder.ApplyConfiguration(seedData.RoleConfiguration);
            modelBuilder.ApplyConfiguration(seedData.UserConfiguration);
            modelBuilder.ApplyConfiguration(seedData.UserRoleConfiguration);
            modelBuilder.ApplyConfiguration(seedData.UserAddressConfiguration);
            modelBuilder.ApplyConfiguration(seedData.RestaurantConfiguration);
            modelBuilder.ApplyConfiguration(seedData.FoodConfiguration);
            modelBuilder.ApplyConfiguration(seedData.ReviewConfiguration);
            modelBuilder.ApplyConfiguration(seedData.OrderConfiguration);
            modelBuilder.ApplyConfiguration(seedData.OrderFoodConfiguration);
            modelBuilder.ApplyConfiguration(seedData.InvoiceConfiguration);
        }
    }
}
