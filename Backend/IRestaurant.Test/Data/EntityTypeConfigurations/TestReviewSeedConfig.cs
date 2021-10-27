using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.Test.Data.EntityTypeConfigurations
{
    public class TestReviewSeedConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(TestSeedService.Reviews);
        }
    }
}