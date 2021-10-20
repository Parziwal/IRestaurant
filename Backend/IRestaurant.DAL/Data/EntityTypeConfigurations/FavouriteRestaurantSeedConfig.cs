using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class FavouriteRestaurantSeedConfig : IEntityTypeConfiguration<FavouriteRestaurant>
    {
        public void Configure(EntityTypeBuilder<FavouriteRestaurant> builder)
        {
            builder.HasData(
                new FavouriteRestaurant
                {
                    Id = 1,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 1
                },
                new FavouriteRestaurant
                {
                    Id = 2,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 2
                },
                new FavouriteRestaurant
                {
                    Id = 3,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 3
                },
                new FavouriteRestaurant
                {
                    Id = 4,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 4
                },
                new FavouriteRestaurant
                {
                    Id = 5,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 5
                }
            );
        }
    }
}
