using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Order
{
    public class OrderFoodDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public OrderFoodDto(OrderFood orderFood, Food food)
        {
            this.Name = food.Name;
            this.Price = orderFood.Price;
            this.Amount = orderFood.Amount;
        }
    }
}
