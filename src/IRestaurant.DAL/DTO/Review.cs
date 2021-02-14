using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class Review
    {
        public int Id { get; }
        public double Rating { get; }
        public string Title { get; }
        public string Description { get; }
        public string UserFullName { get; }

        public Review(Models.Review review, Models.ApplicationUser user)
        {
            this.Id = review.Id;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.Description = review.Description;
            this.UserFullName = user.FullName;
        }
    }
}
