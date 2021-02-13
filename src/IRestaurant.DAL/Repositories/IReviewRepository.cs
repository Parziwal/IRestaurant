using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IReviewRepository
    {
        Task<IReadOnlyCollection<DTO.Review>> GetRestaurantReviews(int restaurantId);
        Task<DTO.Review> AddReviewToRestaurant(int restaurantId, DTO.CreateReview review);
        Task<DTO.Review> DeleteReview(int reviewId);
    }
}
