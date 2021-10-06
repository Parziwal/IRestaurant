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
        /// Ez a met�dus fut�si id�ben h�v�dik meg. A szolg�ltat�sok beregisztr�l�s�ra haszn�latos.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    //Az adatb�zis migr�ci�s f�jlok �thelyez�se a DAL r�tegbe.
                    x => x.MigrationsAssembly("IRestaurant.DAL")));

            services.AddControllers();

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Audience = Configuration.GetSection("IRestaurantWebAPI:Audience").Value;
                options.Authority = Configuration.GetSection("IRestaurantWebAPI:Authority").Value;
            });

            //Scope �s szerepk�r szerinti policy l�trehoz�sa.
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

            // A Swagger szolg�ltat�s beregisztr�l�sa a Swagger middleware haszn�lat�hoz OAuth2 authentik�ci�val.
            services.AddOpenApiDocument(c =>
            {
                c.Version = "v1";
                c.Title = "Restaurant API";
                c.Description = "Egy �tterem kezel� ASP.NET Core webalkalmaz�s REST API le�r�sa.";
                c.AddSecurity("OAuth2", Configuration.GetSection("Swagger:OpenApiSecurityScheme").Get<NSwag.OpenApiSecurityScheme>());
                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("OAuth2"));
            });

            //ProblemDetails Middleware-hez sz�ks�ges szolg�ltat�sok hozz�ad�sa, �s konfigur�l�sa.
            services.AddProblemDetails(options => {
                // Ez 404 Not Found st�tusz k�dra cser�li EntityNotFoundException-t.
                options.Map<EntityNotFoundException>((context, exception) => {
                    var problemDetails = StatusCodeProblemDetails.Create(StatusCodes.Status404NotFound);
                    problemDetails.Title = exception.Message;
                    return problemDetails;
                });
                // Ez 400 Bad Request st�tusz k�dra cser�li EntityAlreadyExistsException-t.
                options.Map<EntityNotFoundException>((context, exception) => {
                    var problemDetails = StatusCodeProblemDetails.Create(StatusCodes.Status400BadRequest);
                    problemDetails.Title = exception.Message;
                    return problemDetails;
                });
            });

            //A HttpContext-hez val� hozz�f�r�s miatt(pl.: a jelenlegi felhaszn�l� lek�r�se).
            services.AddHttpContextAccessor();

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
            services.AddTransient<UserManager>();
        }

        /// <summary>
        /// Ez a met�dus fut�si id�ben h�v�dik meg. A HTTP k�r�si pipline konfigur�ci�j�ra haszn�latos.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ProblemDetails Middleware hozz�ad�sa a k�r�s feldolgoz� pipeline-hoz
            app.UseProblemDetails();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //A Swagger gener�tor �s a Swagger UI middleware beregisztr�l�sa
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
