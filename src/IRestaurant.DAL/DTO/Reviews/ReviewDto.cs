using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Reviews
{
    public class ReviewDto
    {
        public int Id { get; }
        public double Rating { get; }
        public string Title { get; }
        public string Description { get; }
        public string UserFullName { get; }

        public ReviewDto(Review review, ApplicationUser user)
        {
            this.Id = review.Id;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.Description = review.Description;
            this.UserFullName = user.FullName;
        }
    }
}
