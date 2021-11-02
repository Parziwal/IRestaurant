using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using IRestaurant.DAL.Data.EntityTypeConfigurations;
using System.IO;

namespace IRestaurant.DAL.Data
{
    /// <summary>
    /// Megfelelő ApplicationDbContext adatbázis példány létrehozásáért felelős tervezési időben.
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// ApplicationDbContext adatbázis példányt hoz létre.
        /// </summary>
        /// <param name="args">Argumentumok.</param>
        /// <returns>Az adatbázis példány.</returns>
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            return new ApplicationDbContext(optionsBuilder.Options, operationalStoreOptions, new ApplicationSeedData());
        }
    }
}
