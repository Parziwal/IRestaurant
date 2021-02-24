using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Order
{
    public class OrderOverviewDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime PreferredDeliveryDate { get; set; }
        public Status Status { get; set; }
        public int Total { get; set; }
        public string UserFullName { get; set; }
        public string RestaurantName { get; set; }

        public OrderOverviewDto(Models.Order order, int total, Invoice invoice)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.PreferredDeliveryDate = order.PreferredDeliveryDate;
            this.Status = order.status;
            this.Total = total;
            this.UserFullName = invoice.UserFullName;
            this.RestaurantName = invoice.RestaurantName;
        }
    }
}
