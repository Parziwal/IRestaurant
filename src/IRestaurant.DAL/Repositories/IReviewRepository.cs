using IRestaurant.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IReviewRepository
    {
        Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId);
        Task<ReviewDto> AddReviewToRestaurant(string userId, int restaurantId, CreateReviewDto review);
        Task<ReviewDto> DeleteReview(int reviewId);
    }
}
