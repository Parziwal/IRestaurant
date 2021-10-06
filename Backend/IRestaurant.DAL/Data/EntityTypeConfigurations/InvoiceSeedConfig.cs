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
                },
                new Invoice
                {
                    Id = 7,
                    OrderId = 7,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 8,
                    OrderId = 8,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 9,
                    OrderId = 9,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 10,
                    OrderId = 10,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 11,
                    OrderId = 11,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Princess Bakery&Bistro Örs vezér tér",
                },
                new Invoice
                {
                    Id = 12,
                    OrderId = 12,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Twentysix Budapest",
                },
                new Invoice
                {
                    Id = 13,
                    OrderId = 13,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 14,
                    OrderId = 14,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 15,
                    OrderId = 15,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 16,
                    OrderId = 16,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 17,
                    OrderId = 17,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Princess Bakery&Bistro Örs vezér tér",
                },
                new Invoice
                {
                    Id = 18,
                    OrderId = 18,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Twentysix Budapest",
                },
                new Invoice
                {
                    Id = 19,
                    OrderId = 19,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 20,
                    OrderId = 20,
                    UserFullName = "Carson Alexander",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 21,
                    OrderId = 21,
                    UserFullName = "Bács Imre",
                    RestaurantName = "Trófea Grill Étterem - Király",
                },
                new Invoice
                {
                    Id = 22,
                    OrderId = 22,
                    UserFullName = "Bács Imre",
                    RestaurantName = "Trófea Grill Étterem - Király",
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
                },
                new
                {
                    InvoiceId = 7,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 8,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 9,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 10,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 11,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 12,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 13,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 14,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 15,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 16,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 17,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 18,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 19,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 20,
                    City = "Budapest",
                    ZipCode = 1060,
                    Street = "Kossuth utca 30",
                    PhoneNumber = "06201214561"
                },
                new
                {
                    InvoiceId = 21,
                    City = "Budapest",
                    ZipCode = 1017,
                    Street = "Petőfi utca 3",
                    PhoneNumber = "06301451567"
                },
                new
                {
                    InvoiceId = 22,
                    City = "Budapest",
                    ZipCode = 1017,
                    Street = "Petőfi utca 3",
                    PhoneNumber = "06301451567"
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
                },
                new
                {
                    InvoiceId = 7,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 8,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 9,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 10,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 11,
                    City = "Budapest",
                    ZipCode = 1148,
                    Street = "Örs vezér tere 1",
                    PhoneNumber = "06305412567"
                },
                new
                {
                    InvoiceId = 12,
                    City = "Budapest",
                    ZipCode = 1011,
                    Street = "Király utca 26",
                    PhoneNumber = "06301233456"
                },
                new
                {
                    InvoiceId = 13,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 14,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 15,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 16,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 17,
                    City = "Budapest",
                    ZipCode = 1148,
                    Street = "Örs vezér tere 1",
                    PhoneNumber = "06305412567"
                },
                new
                {
                    InvoiceId = 18,
                    City = "Budapest",
                    ZipCode = 1011,
                    Street = "Király utca 26",
                    PhoneNumber = "06301233456"
                },
                new
                {
                    InvoiceId = 19,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 20,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 21,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    InvoiceId = 22,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                }
            );
        }
    }
}
