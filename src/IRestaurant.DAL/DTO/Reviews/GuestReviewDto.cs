using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO.Reviews
{
    public class GuestReviewDto
    {
        public int Id { get; }
        public int ReviewedRestaurantId { get; }
        public string ReviewedRestaurantName { get; }
        public double Rating { get; }
        public string Title { get; }
        public DateTime CreatedAt { get; }
        public string Description { get; }

        public GuestReviewDto(Review review, Restaurant restaurant)
        {
            this.Id = review.Id;
            this.ReviewedRestaurantId = restaurant.Id;
            this.ReviewedRestaurantName = restaurant.Name;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.CreatedAt = review.CreatedAt;
            this.Description = review.Description;
        }
    }
}
