﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public Address UserAddress { get; set; }
        [Required]
        [StringLength(50)]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public Address RestaurantAddress { get; set; }
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
