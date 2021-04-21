using IRestaurant.DAL.DTO.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IReviewRepository
    {
        Task<ReviewDto> GetReview(int reviewId);
        Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviewList(int restaurantId);
        Task<IReadOnlyCollection<ReviewDto>> GetGuestReviewList(string guestId);
        Task<ReviewDto> AddReviewToRestaurant(string userId, int restaurantId, CreateReviewDto review);
        Task DeleteReview(int reviewId);
        Task<string> GetPubliserUserId(int reviewId);
        Task<int> GetRestaurantIdReviewBelongTo(int reviewId);
    }
}
