using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class CreateReview
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
