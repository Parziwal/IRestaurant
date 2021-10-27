using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.Test.Data.EntityTypeConfigurations
{
    public class TestEmptySeedConfig<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
