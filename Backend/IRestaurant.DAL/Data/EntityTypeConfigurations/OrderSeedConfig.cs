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
    public class OrderSeedConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = 1,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now,
                    Status = OrderStatus.PROCESSING,
                    PreferredDeliveryDate = DateTime.Now.AddDays(3)
                },
                new Order
                {
                    Id = 2,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Status = OrderStatus.ORDER_COMPLETION,
                    PreferredDeliveryDate = DateTime.Now.AddDays(1)
                },
                new Order
                {
                    Id = 3,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Status = OrderStatus.UNDER_DELIVERING,
                    PreferredDeliveryDate = DateTime.Now.AddHours(3)
                },
                new Order
                {
                    Id = 4,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-3)
                },
                new Order
                {
                    Id = 5,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now,
                    Status = OrderStatus.PROCESSING,
                    PreferredDeliveryDate = DateTime.Now.AddDays(2)
                },
                new Order
                {
                    Id = 6,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now,
                    Status = OrderStatus.PROCESSING,
                    PreferredDeliveryDate = DateTime.Now.AddDays(1)
                },
                new Order
                {
                    Id = 7,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-25)
                },
                new Order
                {
                    Id = 8,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-35),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-33)
                },
                new Order
                {
                    Id = 9,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-40),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddHours(-38)
                },
                new Order
                {
                    Id = 10,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-43),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-41)
                },
                new Order
                {
                    Id = 11,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-50),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-45)
                },
                new Order
                {
                    Id = 12,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-55),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-52)
                },
                new Order
                {
                    Id = 13,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-60),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-59)
                },
                new Order
                {
                    Id = 14,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-64),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddHours(-61)
                },
                new Order
                {
                    Id = 15,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-69),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-67)
                },
                new Order
                {
                    Id = 16,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-374),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-370)
                },
                new Order
                {
                    Id = 17,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-385),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-381)
                },
                new Order
                {
                    Id = 18,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-392),
                    Status = OrderStatus.CANCELLED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-390)
                },
                new Order
                {
                    Id = 19,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-397),
                    Status = OrderStatus.CANCELLED,
                    PreferredDeliveryDate = DateTime.Now.AddDays(-395)
                },
                new Order
                {
                    Id = 20,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    CreatedAt = DateTime.Now.AddDays(-705),
                    Status = OrderStatus.CANCELLED,
                    PreferredDeliveryDate = DateTime.Now.AddHours(-700)
                },

                new Order
                {
                    Id = 21,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Status = OrderStatus.PROCESSING,
                    PreferredDeliveryDate = DateTime.Now.AddDays(5)
                },
                new Order
                {
                    Id = 22,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    CreatedAt = DateTime.Now.AddDays(-378),
                    Status = OrderStatus.DELIVERED,
                    PreferredDeliveryDate = DateTime.Now.AddHours(-372)
                }
            );
        }
    }
}
