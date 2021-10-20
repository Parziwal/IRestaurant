using IRestaurant.DAL.Data;
using IRestaurant.DAL.Data.EntityTypeConfigurations;
using IRestaurant.DAL.Models;
using IRestaurant.Test.Data.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.Test.Data
{
    public class TestSeedData : IApplicationSeedData
    {
        public IEntityTypeConfiguration<IdentityRole> RoleConfiguration { get; set; } = new TestRolesSeedConfig();
        public IEntityTypeConfiguration<ApplicationUser> UserConfiguration { get; set; } = new TestApplicationUserSeedConfig();
        public IEntityTypeConfiguration<IdentityUserRole<string>> UserRoleConfiguration { get; set; } = new TestUserRolesSeedConfig();
        public IEntityTypeConfiguration<UserAddress> UserAddressConfiguration { get; set; } = new TestEmptySeedConfig<UserAddress>();
        public IEntityTypeConfiguration<Restaurant> RestaurantConfiguration { get; set; } = new TestRestaurantSeedConfig();
        public IEntityTypeConfiguration<Food> FoodConfiguration { get; set; } = new TestEmptySeedConfig<Food>();
        public IEntityTypeConfiguration<Review> ReviewConfiguration { get; set; } = new TestReviewSeedConfig();
        public IEntityTypeConfiguration<Order> OrderConfiguration { get; set; } = new TestEmptySeedConfig<Order>();
        public IEntityTypeConfiguration<OrderFood> OrderFoodConfiguration { get; set; } = new TestEmptySeedConfig<OrderFood>();
        public IEntityTypeConfiguration<Invoice> InvoiceConfiguration { get; set; } = new TestEmptySeedConfig<Invoice>();
        public IEntityTypeConfiguration<FavouriteRestaurant> FavouriteRestaurantConfiguration { get; set; } = new TestFavouriteRestaurantSeedConfig();
    }
}
