using IRestaurant.DAL.Data.EntityTypeConfigurations;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.DAL.Data
{
    /// <summary>
    /// Az adatbázis kezdeti inicializálásához szükséges adatokat tartalmazza.
    /// </summary>
    public interface IApplicationSeedData
    {
        IEntityTypeConfiguration<IdentityRole> RoleConfiguration { get; set; }
        IEntityTypeConfiguration<ApplicationUser> UserConfiguration { get; set; }
        IEntityTypeConfiguration<IdentityUserRole<string>> UserRoleConfiguration { get; set; }
        IEntityTypeConfiguration<UserAddress> UserAddressConfiguration { get; set; }
        IEntityTypeConfiguration<Restaurant> RestaurantConfiguration { get; set; }
        IEntityTypeConfiguration<Food> FoodConfiguration { get; set; }
        IEntityTypeConfiguration<Review> ReviewConfiguration { get; set; }
        IEntityTypeConfiguration<Order> OrderConfiguration { get; set; }
        IEntityTypeConfiguration<OrderFood> OrderFoodConfiguration { get; set; }
        IEntityTypeConfiguration<Invoice> InvoiceConfiguration { get; set; }
        IEntityTypeConfiguration<FavouriteRestaurant> FavouriteRestaurantConfiguration { get; set; }
    }
}
