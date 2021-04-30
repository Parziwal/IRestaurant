using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRestaurant.DAL.DTO.Orders
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime PreferredDeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public int Total { get; set; }
        public string UserFullName { get; set; }
        public AddressDto UserAddress { get; set; }
        public string RestaurantName { get; set; }
        public AddressDto RestaurantAddress { get; set; }
        public List<OrderFoodDto> OrderFoods { get; set; }

        public OrderDetailsDto(Order order)
        {
            this.Id = order.Id;
            this.Date = order.CreatedAt;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.Status;
            this.Total = order.OrderFoods.Sum(of => of.Amount * of.Price);
            this.UserFullName = order.Invoice.UserFullName;
            this.UserAddress = new AddressDto(order.Invoice.UserAddress);
            this.RestaurantName = order.Invoice.RestaurantName;
            this.RestaurantAddress = new AddressDto(order.Invoice.RestaurantAddress);
            this.OrderFoods = order.OrderFoods.Select(of => new OrderFoodDto(of)).ToList();
        }
    }
}
