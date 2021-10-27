using IRestaurant.DAL.Data.EntityTypeConfigurations;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.DAL.Data
{
    public class ApplicationSeedData : IApplicationSeedData
    {
        public IEntityTypeConfiguration<IdentityRole> RoleConfiguration { get; set; } = new RolesSeedConfig();
        public IEntityTypeConfiguration<ApplicationUser> UserConfiguration { get; set; } = new ApplicationUserSeedConfig();
        public IEntityTypeConfiguration<IdentityUserRole<string>> UserRoleConfiguration { get; set; } = new UserRolesSeedConfig();
        public IEntityTypeConfiguration<UserAddress> UserAddressConfiguration { get; set; } = new UserAddressSeedConfig();
        public IEntityTypeConfiguration<Restaurant> RestaurantConfiguration { get; set; } = new RestaurantSeedConfig();
        public IEntityTypeConfiguration<Food> FoodConfiguration { get; set; } = new FoodSeedConfig();
        public IEntityTypeConfiguration<Review> ReviewConfiguration { get; set; } = new ReviewSeedConfig();
        public IEntityTypeConfiguration<Order> OrderConfiguration { get; set; } = new OrderSeedConfig();
        public IEntityTypeConfiguration<OrderFood> OrderFoodConfiguration { get; set; } = new OrderFoodSeedConfig();
        public IEntityTypeConfiguration<Invoice> InvoiceConfiguration { get; set; } = new InvoiceSeedConfig();
        public IEntityTypeConfiguration<FavouriteRestaurant> FavouriteRestaurantConfiguration { get; set; } = new FavouriteRestaurantSeedConfig();
    }
}
