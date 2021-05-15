using Hellang.Middleware.ProblemDetails;
using IdentityServer4.Services;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
using IRestaurant.Web.ProfileServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace IRestaurant.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Ez a metódus futási idõben hívódik meg. A szolgáltatások beregisztrálására használatos.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    //Az adatbázis migrációs fájlok áthelyezése a DAL rétegbe.
                    x => x.MigrationsAssembly("IRestaurant.DAL")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //A Role service beregisztrálása a szerepkörök használatához.
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //A felhasználó szerepkörének (role) tokenbe helyezése.
            services.AddTransient<IProfileService, UserRoleProfileService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            //Restaurant és Guest claim policy beregisztrálása manuálisan.
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Restaurant, policy =>
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Restaurant
                    ));
                options.AddPolicy(UserRoles.Guest, policy =>
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Guest
                ));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            //Production módban az Angular fájlok ebbõl a könyvtárból lesznek kiszolgálva.
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //ProblemDetails Middleware-hez szükséges szolgáltatások hozzáadása, és konfigurálása.
            services.AddProblemDetails(options => {
                // Ez 404 Not Found státusz kódra cseréli EntityNotFoundException-t.
                options.MapToStatusCode<EntityNotFoundException>(StatusCodes.Status404NotFound);
                // Ez 400 Bad Request státusz kódra cseréli EntityAlreadyExistsException-t.
                options.MapToStatusCode<EntityAlreadyExistsException>(StatusCodes.Status400BadRequest);
            });

            //A HttpContext-hez való hozzáférés miatt(pl.: a jelenlegi felhasználó lekérése).
            services.AddHttpContextAccessor();

            // A Swagger szolgáltatás beregisztrálása a Swagger middleware használatához.
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Restaurant API";
                    document.Info.Description = "Egy étterem kezelõ ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Stedra Kristóf",
                        Email = string.Empty,
                    };
                };
            });

            //A DAL rétegbeli repository osztályok beregisztrálása.
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();

            //A BL rétegbeli manager osztályok beregisztrálása.
            services.AddTransient<RestaurantManager>();
            services.AddTransient<ReviewManager>();
            services.AddTransient<FoodManager>();
            services.AddTransient<OrderManager>();
            services.AddTransient<UserAddressManager>();
        }

        /// <summary>
        /// Ez a metódus futási idõben hívódik meg. A HTTP kérési pipline konfigurációjára használatos.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //ProblemDetails Middleware hozzáadása a kérés feldolgozó pipeline-hoz
            app.UseProblemDetails();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //A Swagger generátor és a Swagger UI middleware beregisztrálása
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //Az Angular kliens alkalmazás és a szerver futásának szétválasztása.
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
