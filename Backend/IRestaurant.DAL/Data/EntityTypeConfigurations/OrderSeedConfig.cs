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
                }
            );
        }
    }
}
