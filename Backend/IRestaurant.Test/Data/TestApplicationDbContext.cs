using IdentityServer4.EntityFramework.Options;
using IRestaurant.DAL.Data;
using IRestaurant.Test.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IRestaurant.Test.Data
{
    public class TestApplicationDbContext
    {
        public TestApplicationDbContext()
        {
            InitDbContext();
        }

        public ApplicationDbContext CreateDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                        .UseInMemoryDatabase(databaseName: "TestDb").Options;
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            return new ApplicationDbContext(contextOptions, operationalStoreOptions, new TestSeedData());
        }

        public void InitDbContext()
        {
            using (var dbContext = CreateDbContext())
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
