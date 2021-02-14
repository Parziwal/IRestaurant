using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Models
{
    public class FavouriteRestaurant
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public ApplicationUser User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
