using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Orders
{
    public class OrderDto
    {
        public int Id { get; }
        public DateTime Date { get; }
        public DateTime PreferredDeliveryDate { get; }
        public Status Status { get; }
        public int Total { get; }
        public string UserFullName { get; }
        public AddressDto UserAddress { get; }
        public string RestaurantName { get; }
        public AddressDto RestaurantAddress { get; }
        public List<OrderFoodDto> OrderFoods { get; }

        public OrderDto(Order order, int total, Invoice invoice, ICollection<OrderFood> orderFood)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.Status;
            this.Total = total;
            this.UserFullName = invoice.UserFullName;
            this.UserAddress = new AddressDto(invoice.UserAddress);
            this.RestaurantName = invoice.RestaurantName;
            this.RestaurantAddress = new AddressDto(invoice.RestaurantAddress);
            this.OrderFoods = orderFood.Select(of => new OrderFoodDto(of, of.Food)).ToList();
        }
    }
}
