using IRestaurant.DAL.Data.EntityTypeConfigurations;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.DAL.Data
{
    public class ApplicationSeedData
    {
        public IEntityTypeConfiguration<IdentityRole> RoleConfiguration { get; set; } = new EmptySeedConfig<IdentityRole>();
        public IEntityTypeConfiguration<ApplicationUser> UserConfiguration { get; set; } = new EmptySeedConfig<ApplicationUser>();
        public IEntityTypeConfiguration<IdentityUserRole<string>> UserRoleConfiguration { get; set; } = new EmptySeedConfig<IdentityUserRole<string>>();
        public IEntityTypeConfiguration<UserAddress> UserAddressConfiguration { get; set; } = new EmptySeedConfig<UserAddress>();
        public IEntityTypeConfiguration<Restaurant> RestaurantConfiguration { get; set; } = new EmptySeedConfig<Restaurant>();
        public IEntityTypeConfiguration<Food> FoodConfiguration { get; set; } = new EmptySeedConfig<Food>();
        public IEntityTypeConfiguration<Review> ReviewConfiguration { get; set; } = new EmptySeedConfig<Review>();
        public IEntityTypeConfiguration<Order> OrderConfiguration { get; set; } = new EmptySeedConfig<Order>();
        public IEntityTypeConfiguration<OrderFood> OrderFoodConfiguration { get; set; } = new EmptySeedConfig<OrderFood>();
        public IEntityTypeConfiguration<Invoice> InvoiceConfiguration { get; set; } = new EmptySeedConfig<Invoice>();
    }
}
