using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class UserAddressSeedConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasData(
                new UserAddress
                {
                    Id = 1,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b"
                },
                new UserAddress
                {
                    Id = 2,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93"
                },
                new UserAddress
                {
                    Id = 3,
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4"
                },
                new UserAddress
                {
                    Id = 4,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761"
                },
                new UserAddress
                {
                    Id = 5,
                    UserId = "fef0a15c-42bb-4f2d-9a65-382d4d95f667"
                }
            );

            builder.OwnsOne(ua => ua.Address).HasData(
                new
                {
                    UserAddressId = 1,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06-20-121-4561"
                },
                new
                {
                    UserAddressId = 2,
                    City = "Budapest",
                    ZipCode = 1017,
                    Street = "Petőfi utca 3",
                    PhoneNumber = "06-30-145-1567"
                },
                new
                {
                    UserAddressId = 3,
                    City = "Szeged",
                    ZipCode = 6725,
                    Street = "Kálmán utca 2",
                    PhoneNumber = "06-30-145-5892"
                },
                new
                {
                    UserAddressId = 4,
                    City = "Debrecen",
                    ZipCode = 4028,
                    Street = "Erdei utca 32",
                    PhoneNumber = "06-20-135-1961"
                },
                new
                {
                    UserAddressId = 5,
                    City = "Eger",
                    ZipCode = 3300,
                    Street = "Liget utca 11",
                    PhoneNumber = "06-30-145-1861"
                }
            );
        }
    }
}
