using IdentityServer4.EntityFramework.Options;
using IRestaurant.DAL.Data;
using IRestaurant.Test.Data;
using IRestaurant.Test.Data.EntityTypeConfigurations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Data.Common;

namespace IRestaurant.Test.RepositoryUnitTests
{
    public class SqliteInMemoryRepositoryTest : IDisposable
    {
        private DbConnection connection;

        public SqliteInMemoryRepositoryTest()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            using(var dbContext = CreateDbContext())
            {
                dbContext.Database.EnsureCreated();
            }
        }

        public ApplicationDbContext CreateDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseSqlite(connection).Options;
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            return new ApplicationDbContext(contextOptions, operationalStoreOptions, new TestSeedData());
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
