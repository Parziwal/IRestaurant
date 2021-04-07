using Hellang.Middleware.ProblemDetails;
using IdentityServer4.Services;
using IRestaurant.BL;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("IRestaurant.DAL")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //Hogy a felhaszn�l� szerepk�r�t (role) le tudjuk k�rdezni oidc kliens seg�ts�g�vel:
            //Ez�ltal a role megjelenik az access tokenben kliens oldalon.
            services.AddTransient<IProfileService, UserRoleProfileService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            //Restaurant �s Guest claim policy beregisztr�l�sa manu�lisan, mivel
            //a be�p�tett szerepk�r alap� enged�lyez�s nem m�k�d�tt megfelel�en,
            //403-as st�tuszk�d� hib�kat dobott a megfelel� szerepk�rrel rendelkez� felhaszn�l�knak is.
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
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //ProblemDetails Middleware-hez sz�ks�ges szolg�ltat�sok hozz�ad�sa, �s konfigur�l�sa
            services.AddProblemDetails(options => {
                // Ez 404 Not Found st�tusz k�dra cser�li EntityNotFoundException-t.
                options.MapToStatusCode<EntityNotFoundException>(StatusCodes.Status404NotFound);
                // Ez 400 Bad Request st�tusz k�dra cser�li EntityAlreadyExistsException-t.
                options.MapToStatusCode<EntityAlreadyExistsException>(StatusCodes.Status400BadRequest);
            });

            services.AddHttpContextAccessor();

            // A Swagger szolg�ltat�s beregisztr�l�sa a Swagger middleware haszn�lat�hoz
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

            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();

            services.AddTransient<RestaurantManager>();
            services.AddTransient<ReviewManager>();
            services.AddTransient<FoodManager>();
            services.AddTransient<OrderManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
