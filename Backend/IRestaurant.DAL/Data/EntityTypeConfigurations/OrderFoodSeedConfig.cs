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
                },

                new OrderFood
                {
                    Id = 25,
                    OrderId = 7,
                    FoodId = 1,
                    Amount = 3,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 26,
                    OrderId = 7,
                    FoodId = 3,
                    Amount = 2,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 27,
                    OrderId = 7,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },
                new OrderFood
                {
                    Id = 28,
                    OrderId = 7,
                    FoodId = 5,
                    Amount = 1,
                    Price = 1090
                },

                new OrderFood
                {
                    Id = 29,
                    OrderId = 8,
                    FoodId = 1,
                    Amount = 1,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 30,
                    OrderId = 8,
                    FoodId = 2,
                    Amount = 1,
                    Price = 3650
                },
                new OrderFood
                {
                    Id = 31,
                    OrderId = 8,
                    FoodId = 3,
                    Amount = 2,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 32,
                    OrderId = 8,
                    FoodId = 8,
                    Amount = 1,
                    Price = 1250
                },

                new OrderFood
                {
                    Id = 33,
                    OrderId = 9,
                    FoodId = 5,
                    Amount = 2,
                    Price = 1090
                },
                new OrderFood
                {
                    Id = 34,
                    OrderId = 9,
                    FoodId = 6,
                    Amount = 1,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 35,
                    OrderId = 9,
                    FoodId = 3,
                    Amount = 2,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 36,
                    OrderId = 9,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 37,
                    OrderId = 10,
                    FoodId = 7,
                    Amount = 4,
                    Price = 1400
                },
                new OrderFood
                {
                    Id = 38,
                    OrderId = 10,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 39,
                    OrderId = 10,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 40,
                    OrderId = 10,
                    FoodId = 4,
                    Amount = 3,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 41,
                    OrderId = 11,
                    FoodId = 9,
                    Amount = 1,
                    Price = 2490
                },
                new OrderFood
                {
                    Id = 42,
                    OrderId = 11,
                    FoodId = 10,
                    Amount = 1,
                    Price = 2390
                },
                new OrderFood
                {
                    Id = 43,
                    OrderId = 11,
                    FoodId = 11,
                    Amount = 1,
                    Price = 2190
                },
                new OrderFood
                {
                    Id = 44,
                    OrderId = 11,
                    FoodId = 12,
                    Amount = 1,
                    Price = 2190
                },

                new OrderFood
                {
                    Id = 45,
                    OrderId = 12,
                    FoodId = 15,
                    Amount = 1,
                    Price = 3550
                },
                new OrderFood
                {
                    Id = 46,
                    OrderId = 12,
                    FoodId = 16,
                    Amount = 3,
                    Price = 4950
                },
                new OrderFood
                {
                    Id = 47,
                    OrderId = 12,
                    FoodId = 17,
                    Amount = 1,
                    Price = 2950
                },
                new OrderFood
                {
                    Id = 48,
                    OrderId = 12,
                    FoodId = 18,
                    Amount = 1,
                    Price = 7650
                },

                new OrderFood
                {
                    Id = 49,
                    OrderId = 13,
                    FoodId = 1,
                    Amount = 5,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 50,
                    OrderId = 13,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 51,
                    OrderId = 13,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },
                new OrderFood
                {
                    Id = 52,
                    OrderId = 13,
                    FoodId = 5,
                    Amount = 2,
                    Price = 1090
                },

                new OrderFood
                {
                    Id = 53,
                    OrderId = 14,
                    FoodId = 1,
                    Amount = 1,
                    Price = 4750
                },
                new OrderFood
                {
                    Id = 54,
                    OrderId = 14,
                    FoodId = 2,
                    Amount = 5,
                    Price = 3650
                },
                new OrderFood
                {
                    Id = 55,
                    OrderId = 14,
                    FoodId = 3,
                    Amount = 2,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 56,
                    OrderId = 14,
                    FoodId = 8,
                    Amount = 1,
                    Price = 1250
                },

                new OrderFood
                {
                    Id = 57,
                    OrderId = 15,
                    FoodId = 5,
                    Amount = 2,
                    Price = 1090
                },
                new OrderFood
                {
                    Id = 58,
                    OrderId = 15,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 59,
                    OrderId = 15,
                    FoodId = 3,
                    Amount = 2,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 60,
                    OrderId = 15,
                    FoodId = 4,
                    Amount = 2,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 61,
                    OrderId = 16,
                    FoodId = 7,
                    Amount = 1,
                    Price = 1400
                },
                new OrderFood
                {
                    Id = 62,
                    OrderId = 16,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 63,
                    OrderId = 16,
                    FoodId = 3,
                    Amount = 1,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 64,
                    OrderId = 16,
                    FoodId = 4,
                    Amount = 3,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 65,
                    OrderId = 17,
                    FoodId = 9,
                    Amount = 6,
                    Price = 2490
                },
                new OrderFood
                {
                    Id = 66,
                    OrderId = 17,
                    FoodId = 10,
                    Amount = 4,
                    Price = 2390
                },
                new OrderFood
                {
                    Id = 67,
                    OrderId = 17,
                    FoodId = 11,
                    Amount = 2,
                    Price = 2190
                },
                new OrderFood
                {
                    Id = 68,
                    OrderId = 17,
                    FoodId = 12,
                    Amount = 2,
                    Price = 2190
                },

                new OrderFood
                {
                    Id = 69,
                    OrderId = 18,
                    FoodId = 15,
                    Amount = 2,
                    Price = 3550
                },
                new OrderFood
                {
                    Id = 70,
                    OrderId = 18,
                    FoodId = 16,
                    Amount = 2,
                    Price = 4950
                },
                new OrderFood
                {
                    Id = 71,
                    OrderId = 18,
                    FoodId = 17,
                    Amount = 2,
                    Price = 2950
                },
                new OrderFood
                {
                    Id = 72,
                    OrderId = 18,
                    FoodId = 18,
                    Amount = 2,
                    Price = 7650
                },

                new OrderFood
                {
                    Id = 73,
                    OrderId = 19,
                    FoodId = 5,
                    Amount = 1,
                    Price = 1090
                },
                new OrderFood
                {
                    Id = 74,
                    OrderId = 19,
                    FoodId = 6,
                    Amount = 1,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 75,
                    OrderId = 19,
                    FoodId = 3,
                    Amount = 1,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 76,
                    OrderId = 19,
                    FoodId = 4,
                    Amount = 1,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 77,
                    OrderId = 20,
                    FoodId = 7,
                    Amount = 3,
                    Price = 1400
                },
                new OrderFood
                {
                    Id = 78,
                    OrderId = 20,
                    FoodId = 6,
                    Amount = 3,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 79,
                    OrderId = 20,
                    FoodId = 3,
                    Amount = 3,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 80,
                    OrderId = 20,
                    FoodId = 4,
                    Amount = 3,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 81,
                    OrderId = 21,
                    FoodId = 5,
                    Amount = 2,
                    Price = 1090
                },
                new OrderFood
                {
                    Id = 82,
                    OrderId = 21,
                    FoodId = 6,
                    Amount = 4,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 83,
                    OrderId = 21,
                    FoodId = 3,
                    Amount = 4,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 84,
                    OrderId = 21,
                    FoodId = 4,
                    Amount = 4,
                    Price = 900
                },

                new OrderFood
                {
                    Id = 85,
                    OrderId = 22,
                    FoodId = 7,
                    Amount = 1,
                    Price = 1400
                },
                new OrderFood
                {
                    Id = 86,
                    OrderId = 22,
                    FoodId = 6,
                    Amount = 2,
                    Price = 1250
                },
                new OrderFood
                {
                    Id = 87,
                    OrderId = 22,
                    FoodId = 3,
                    Amount = 1,
                    Price = 3700
                },
                new OrderFood
                {
                    Id = 88,
                    OrderId = 22,
                    FoodId = 4,
                    Amount = 2,
                    Price = 900
                }
            );
        }
    }
}
