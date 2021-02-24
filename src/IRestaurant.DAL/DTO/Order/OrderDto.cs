using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime PreferredDeliveryDate { get; set; }
        public Status Status { get; set; }
        public int Total { get; set; }
        public string UserFullName { get; set; }
        public AddressDto UserAddress { get; set; }
        public string RestaurantName { get; set; }
        public AddressDto RestaurantAddress { get; set; }
        public List<OrderFoodDto> OrderFoods { get; set; }

        public OrderDto(Models.Order order, int total, Invoice invoice, ICollection<OrderFood> orderFood)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.status;
            this.Total = total;
            this.UserFullName = invoice.UserFullName;
            this.UserAddress = new AddressDto(invoice.UserAddress);
            this.RestaurantName = invoice.RestaurantName;
            this.RestaurantAddress = new AddressDto(invoice.RestaurantAddress);
            this.OrderFoods = orderFood.Select(of => new OrderFoodDto(of, of.Food)).ToList();
        }
    }
}
