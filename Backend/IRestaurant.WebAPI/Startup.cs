using Hellang.Middleware.ProblemDetails;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;
using System.Security.Claims;

namespace IRestaurant.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string DEFAULT_CORS_POLICY = "DefaultCORSPolicy";
        private const string IRESTAURANT_API_SCOPE = "IRestaurantAPIScope";

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

            services.AddControllers();

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Audience = Configuration.GetSection("IRestaurantWebAPI:Audience").Value;
                options.Authority = Configuration.GetSection("IRestaurantWebAPI:Authority").Value;
            });

            //Scope és szerepkör szerinti policy létrehozása.
            services.AddAuthorization(options =>
            {
                options.AddPolicy(IRESTAURANT_API_SCOPE, policy => {
                    policy.RequireClaim("scope", Configuration.GetSection("IRestaurantWebAPI:Scope").Value);
                });
                options.AddPolicy(UserRoles.Restaurant, policy =>
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Restaurant
                    ));
                options.AddPolicy(UserRoles.Guest, policy =>
                    policy.RequireClaim(ClaimTypes.Role, UserRoles.Guest
                ));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_CORS_POLICY, policy =>
                {
                    policy.WithOrigins(Configuration.GetSection("IRestaurantWebAPI:AllowedCorsOrigins").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // A Swagger szolgáltatás beregisztrálása a Swagger middleware használatához OAuth2 authentikációval.
            services.AddOpenApiDocument(c =>
            {
                c.Version = "v1";
                c.Title = "Restaurant API";
                c.Description = "Egy étterem kezelõ ASP.NET Core webalkalmazás REST API leírása.";
                c.AddSecurity("OAuth2", Configuration.GetSection("Swagger:OpenApiSecurityScheme").Get<NSwag.OpenApiSecurityScheme>());
                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("OAuth2"));
            });

            //ProblemDetails Middleware-hez szükséges szolgáltatások hozzáadása, és konfigurálása.
            services.AddProblemDetails(options => {
                // Ez 404 Not Found státusz kódra cseréli EntityNotFoundException-t.
                options.Map<EntityNotFoundException>((context, exception) => {
                    var problemDetails = StatusCodeProblemDetails.Create(StatusCodes.Status404NotFound);
                    problemDetails.Title = exception.Message;
                    return problemDetails;
                });
                // Ez 400 Bad Request státusz kódra cseréli EntityAlreadyExistsException-t.
                options.Map<EntityNotFoundException>((context, exception) => {
                    var problemDetails = StatusCodeProblemDetails.Create(StatusCodes.Status400BadRequest);
                    problemDetails.Title = exception.Message;
                    return problemDetails;
                });
            });

            //A HttpContext-hez való hozzáférés miatt(pl.: a jelenlegi felhasználó lekérése).
            services.AddHttpContextAccessor();

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
            services.AddTransient<UserManager>();
        }

        /// <summary>
        /// Ez a metódus futási idõben hívódik meg. A HTTP kérési pipline konfigurációjára használatos.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ProblemDetails Middleware hozzáadása a kérés feldolgozó pipeline-hoz
            app.UseProblemDetails();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //A Swagger generátor és a Swagger UI middleware beregisztrálása
            app.UseOpenApi();
            app.UseSwaggerUi3(config =>
            {
                config.OAuth2Client = Configuration.GetSection("Swagger:OAuth2ClientSettings").Get<OAuth2ClientSettings>();
            });

            app.UseRouting();

            app.UseCors(DEFAULT_CORS_POLICY);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}")
                .RequireAuthorization(IRESTAURANT_API_SCOPE);
            });
        }
    }
}
