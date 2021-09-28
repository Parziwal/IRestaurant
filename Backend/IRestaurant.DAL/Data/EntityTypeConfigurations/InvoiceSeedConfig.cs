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
    class InvoiceSeedConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(
                new Invoice
                {
                    Id = 1,
                    OrderId = 1,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 2,
                    OrderId = 2,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 3,
                    OrderId = 3,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 4,
                    OrderId = 4,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 5,
                    OrderId = 5,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Princess Bakery&Bistro Örs vezér tér",
                },
                new Invoice
                {
                    Id = 6,
                    OrderId = 6,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Twentysix Budapest",
                }
            );

            builder.OwnsOne(i => i.UserAddress).HasData(
                new
                {
                    InvoiceId = 1,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 2,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 3,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 4,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                }, 
                new
                {
                    InvoiceId = 5,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 6,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                }
            );

            builder.OwnsOne(i => i.RestaurantAddress).HasData(
                new
                {
                    InvoiceId = 1,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 2,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 3,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 4,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 5,
                    City = "Budapest",
                    ZipCode = 1148,
                    Street = "Örs vezér tere 1",
                    PhoneNumber = "06305412567"
                },
                new
                {
                    InvoiceId = 6,
                    City = "Budapest",
                    ZipCode = 1011,
                    Street = "Király utca 26",
                    PhoneNumber = "06301233456"
                }
            );
        }
    }
}
