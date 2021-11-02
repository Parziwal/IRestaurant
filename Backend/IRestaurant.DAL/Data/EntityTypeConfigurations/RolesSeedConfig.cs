using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class RolesSeedConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "rc95a82e-0abc-4d85-9877-4184177c3a7f",
                    Name = UserRoles.Restaurant,
                    NormalizedName = UserRoles.Restaurant.ToUpper(),
                    ConcurrencyStamp = "e388975f-eb14-4f40-ba09-159e4164b513",
                },
                new IdentityRole
                {
                    Id = "g8aceb4d-b534-459e-8c4e-d13374f43b65",
                    Name = UserRoles.Guest,
                    NormalizedName = UserRoles.Guest.ToUpper(),
                    ConcurrencyStamp = "24d76572-e1bb-4588-b442-b3907c67e05e",
                }
            );
        }
    }
}
