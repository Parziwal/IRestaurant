using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using IRestaurant.DAL.Data.EntityTypeConfigurations;
using System.IO;

namespace IRestaurant.DAL.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    { 

        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            var seedData = new ApplicationSeedData();
            seedData.RoleConfiguration = new RolesSeedConfig();
            seedData.UserConfiguration = new ApplicationUserSeedConfig();
            seedData.UserRoleConfiguration = new UserRolesSeedConfig();
            seedData.UserAddressConfiguration  = new UserAddressSeedConfig();
            seedData.RestaurantConfiguration = new RestaurantSeedConfig();
            seedData.FoodConfiguration = new FoodSeedConfig();
            seedData.ReviewConfiguration = new ReviewSeedConfig();
            seedData.OrderConfiguration = new OrderSeedConfig();
            seedData.OrderFoodConfiguration = new OrderFoodSeedConfig();
            seedData.InvoiceConfiguration = new InvoiceSeedConfig();

            return new ApplicationDbContext(optionsBuilder.Options, operationalStoreOptions, new ApplicationSeedData());
        }
    }
}
