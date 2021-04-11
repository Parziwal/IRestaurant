using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Orders
{
    public class OrderOverviewDto
    {
        public int Id { get; }
        public DateTime Date { get; }
        public DateTime PreferredDeliveryDate { get; }
        public OrderStatus Status { get; }
        public int Total { get; }
        public string UserFullName { get; }
        public string RestaurantName { get; }

        public OrderOverviewDto(Order order, int total, Invoice invoice)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.Status;
            this.Total = total;
            this.UserFullName = invoice.UserFullName;
            this.RestaurantName = invoice.RestaurantName;
        }
    }
}
