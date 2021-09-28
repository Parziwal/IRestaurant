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
    public class OrderFoodSeedConfig : IEntityTypeConfiguration<OrderFood>
    {
        public void Configure(EntityTypeBuilder<OrderFood> builder)
        {
            builder.HasData(
                new OrderFood
                {
                    Id = 1,
                    OrderId = 1,
                    FoodId = 1,
                    Amount = 3,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 2,
                    OrderId = 1,
                    FoodId = 2,
                    Amount = 2,
                    Price = 3650
                },
                new OrderFood
                {
                    Id = 3,
                    OrderId = 1,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 4,
                    OrderId = 1,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 5,
                    OrderId = 2,
                    FoodId = 1,
                    Amount = 1,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 6,
                    OrderId = 2,
                    FoodId = 2,
                    Amount = 2,
                    Price = 3650
                },
                new OrderFood
                {
                    Id = 7,
                    OrderId = 2,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 8,
                    OrderId = 2,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 9,
                    OrderId = 3,
                    FoodId = 5,
                    Amount = 1,
                    Price = 1090
                },
                new OrderFood
                {
                    Id = 10,
                    OrderId = 3,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 11,
                    OrderId = 3,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 12,
                    OrderId = 3,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 13,
                    OrderId = 4,
                    FoodId = 7,
                    Amount = 2,
                    Price = 1400
                },
                new OrderFood
                {
                    Id = 14,
                    OrderId = 4,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 15,
                    OrderId = 4,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 16,
                    OrderId = 4,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 17,
                    OrderId = 5,
                    FoodId = 9,
                    Amount = 3,
                    Price = 2490
                },
                new OrderFood
                {
                    Id = 18,
                    OrderId = 5,
                    FoodId = 10,
                    Amount = 2,
                    Price = 2390
                },
                new OrderFood
                {
                    Id = 19,
                    OrderId = 5,
                    FoodId = 11,
                    Amount = 4,
                    Price = 2190
                },
                new OrderFood
                {
                    Id = 20,
                    OrderId = 5,
                    FoodId = 12,
                    Amount = 1,
                    Price = 2190
                },

                new OrderFood
                {
                    Id = 21,
                    OrderId = 6,
                    FoodId = 15,
                    Amount = 1,
                    Price = 3550
                },
                new OrderFood
                {
                    Id = 22,
                    OrderId = 6,
                    FoodId = 16,
                    Amount = 2,
                    Price = 4950
                },
                new OrderFood
                {
                    Id = 23,
                    OrderId = 6,
                    FoodId = 17,
                    Amount = 1,
                    Price = 2950
                },
                new OrderFood
                {
                    Id = 24,
                    OrderId = 6,
                    FoodId = 18,
                    Amount = 2,
                    Price = 7650
                }
            );
        }
    }
}
