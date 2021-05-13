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
        /// Ez a met�dus fut�si id�ben h�v�dik meg. A szolg�ltat�sok beregisztr�l�s�ra haszn�latos.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    //Az adatb�zis migr�ci�s f�jlok �thelyez�se a DAL r�tegbe.
                    x => x.MigrationsAssembly("IRestaurant.DAL")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //A Role service beregisztr�l�sa a szerepk�r�k haszn�lat�hoz.
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //A felhaszn�l� szerepk�r�nek (role) tokenbe helyez�se.
            services.AddTransient<IProfileService, UserRoleProfileService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            //Restaurant �s Guest claim policy beregisztr�l�sa manu�lisan.
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

            //Production m�dban az Angular f�jlok ebb�l a k�nyvt�rb�l lesznek kiszolg�lva.
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //ProblemDetails Middleware-hez sz�ks�ges szolg�ltat�sok hozz�ad�sa, �s konfigur�l�sa.
            services.AddProblemDetails(options => {
                // Ez 404 Not Found st�tusz k�dra cser�li EntityNotFoundException-t.
                options.MapToStatusCode<EntityNotFoundException>(StatusCodes.Status404NotFound);
                // Ez 400 Bad Request st�tusz k�dra cser�li EntityAlreadyExistsException-t.
                options.MapToStatusCode<EntityAlreadyExistsException>(StatusCodes.Status400BadRequest);
            });

            //A HttpContext-hez val� hozz�f�r�s miatt(pl.: a jelenlegi felhaszn�l� lek�r�se).
            services.AddHttpContextAccessor();

            // A Swagger szolg�ltat�s beregisztr�l�sa a Swagger middleware haszn�lat�hoz.
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Restaurant API";
                    document.Info.Description = "Egy �tterem kezel� ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Stedra Krist�f",
                        Email = string.Empty,
                    };
                };
            });

            //A DAL r�tegbeli repository oszt�lyok beregisztr�l�sa.
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();

            //A BL r�tegbeli manager oszt�lyok beregisztr�l�sa.
            services.AddTransient<RestaurantManager>();
            services.AddTransient<ReviewManager>();
            services.AddTransient<FoodManager>();
            services.AddTransient<OrderManager>();
            services.AddTransient<UserAddressManager>();
        }

        /// <summary>
        /// Ez a met�dus fut�si id�ben h�v�dik meg. A HTTP k�r�si pipline konfigur�ci�j�ra haszn�latos.
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

            //ProblemDetails Middleware hozz�ad�sa a k�r�s feldolgoz� pipeline-hoz
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

            //A Swagger gener�tor �s a Swagger UI middleware beregisztr�l�sa
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //Az Angular kliens alkalmaz�s �s a szerver fut�s�nak sz�tv�laszt�sa.
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
