using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    [Owned]
    public class RestaurantAddress
    {
        [Range(1000, 9999)]
        public int? ZipCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
