using IRestaurant.DAL.Models;
using System;
using System.Linq;

namespace IRestaurant.DAL.DTO.Orders
{
    public class OrderOverviewDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime PreferredDeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public int Total { get; set; }
        public string UserFullName { get; set; }
        public string RestaurantName { get; set; }

        public OrderOverviewDto(Order order)
        {
            this.Id = order.Id;
            this.Date = order.CreatedAt;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.Status;
            this.Total = order.OrderFoods.Sum(of => of.Amount * of.Price);
            this.UserFullName = order.Invoice.UserFullName;
            this.RestaurantName = order.Invoice.RestaurantName;
        }
    }
}
