using IRestaurant.DAL.Data;
using IRestaurant.Test.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Test.WebAPIIntegrationTests
{
    public class WebServerFixture : ApplicationDbContextInit, IDisposable
    {
        public TestServer webApiServer;
        public TestServer authServer;

        public ApplicationDbContext DbContext { get; }
        private IDbContextTransaction transaction;

        public WebServerFixture()
        {
            webApiServer = new TestServer(CreateWebAPIWebHostBuilder());
            webApiServer.BaseAddress = new Uri(Configuration.GetSection("WebServer:WebAPIUrl").Value);

            authServer = new TestServer(CreateAuthWebHostBuilder());
            authServer.BaseAddress = new Uri(Configuration.GetSection("WebServer:AuthUrl").Value);

            DbContext = webApiServer.Host.Services.GetService<ApplicationDbContext>();
            transaction = DbContext.Database.BeginTransaction();
        }

        private IWebHostBuilder CreateWebAPIWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseEnvironment(Environments.Development)
                .UseConfiguration(Configuration)
                .UseWebRoot(Configuration.GetSection("IRestaurantWebAPI:WebRoot").Value)
                .UseStartup<WebAPI.Startup>()
                .ConfigureServices(services =>
                {
                    var dbDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                    services.Remove(dbDescriptor);

                    var seedDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IApplicationSeedData));
                    services.Remove(seedDescriptor);

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                    }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);

                    services.AddSingleton<IApplicationSeedData, TestSeedData>();

                    services.PostConfigure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            SignatureValidator = (token, parameters) => new JwtSecurityToken(token)
                        };
                        options.Audience = Configuration.GetSection("IRestaurantWebAPI:Audience").Value;
                        options.Authority = Configuration.GetSection("IRestaurantWebAPI:Authority").Value;
                        options.BackchannelHttpHandler = new MockBackChannel();
                        options.MetadataAddress = Configuration.GetSection("IRestaurantWebAPI:MetadataAddress").Value;
                    });
                });
        }

        private IWebHostBuilder CreateAuthWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseEnvironment(Environments.Development)
                .UseConfiguration(Configuration)
                .UseStartup<Auth.Startup>();
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
            }

            string imagesFolder = $"{Configuration.GetSection("IRestaurantWebAPI:WebRoot").Value}/images";
            if (Directory.Exists(imagesFolder))
            {
                Directory.Delete(imagesFolder, true);
            }
        }
    }
}
