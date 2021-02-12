using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Method { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
