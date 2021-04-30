using IRestaurant.DAL.Models;
using System;

namespace IRestaurant.DAL.DTO.Reviews
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public ReviewDto(Review review)
        {
            this.Id = review.Id;
            this.Rating = review.Rating;
            this.Title = review.Title;
            this.CreatedAt = review.CreatedAt;
            this.Description = review.Description;
            this.UserId = review.User.Id;
            this.UserFullName = review.User.FullName;
            this.RestaurantId = review.Restaurant.Id;
            this.RestaurantName = review.Restaurant.Name;
        }
    }
}
