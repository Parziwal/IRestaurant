using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
        public string UserId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ApplicationUser User { get; set; }
    }
}
