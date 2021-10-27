using IdentityServer4.EntityFramework.Options;
using IRestaurant.DAL.Data;
using IRestaurant.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Test.WebAPIIntegrationTests
{
    public class ApplicationDbContextInit
    {
        protected static IConfiguration Configuration { get; }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        static ApplicationDbContextInit()
        {
            Configuration = GetConfiguration();
            CreateDatabase();
        }

        private static void CreateDatabase()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options;
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            new ApplicationDbContext(contextOptions, operationalStoreOptions, new TestSeedData()).Database.EnsureCreated();
        }
    }
}
