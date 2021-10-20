using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class TestFavouriteRestaurantSeedConfig : IEntityTypeConfiguration<FavouriteRestaurant>
    {
        public void Configure(EntityTypeBuilder<FavouriteRestaurant> builder)
        {
            builder.HasData(TestSeedService.FavouriteRestaurants);
        }
    }
}
