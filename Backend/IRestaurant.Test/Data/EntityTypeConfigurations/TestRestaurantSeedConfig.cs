using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace IRestaurant.Test.Data.EntityTypeConfigurations
{
    public class TestRestaurantSeedConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(TestSeedService.Restaurants.Select(r => new Restaurant {
                Id = r.Id,
                Name = r.Name,
                ShortDescription = r.ShortDescription,
                DetailedDescription = r.DetailedDescription,
                ShowForUsers = r.ShowForUsers,
                IsOrderAvailable = r.IsOrderAvailable,
                OwnerId = r.OwnerId,
                ImagePath = r.ImagePath
            }));
            builder.OwnsOne(r => r.Address).HasData(TestSeedService.Restaurants.Select(r => new {
                RestaurantId = r.Id,
                City = r.Address.City,
                ZipCode = r.Address.ZipCode,
                Street = r.Address.Street,
                PhoneNumber = r.Address.PhoneNumber
            }));
        }
    }
}