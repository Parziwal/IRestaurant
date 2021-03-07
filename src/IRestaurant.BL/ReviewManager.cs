using Hellang.Middleware.ProblemDetails;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BL
{
    public class ReviewManager
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        public ReviewManager(IReviewRepository reviewRepository,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository)
        {
            this.reviewRepository = reviewRepository;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
        }

        public async Task<ReviewDto> GetReview(int reviewId)
        {
            try
            {
                int reviewRestaurantId = await reviewRepository.GetRestaurantIdReviewBelongTo(reviewId);

                if (await restaurantRepository.IsRestaurantAvailableForUsers(reviewRestaurantId))
                {
                    return await reviewRepository.GetReview(reviewId);
                }

                string userId = userRepository.GetCurrentUserId();
                string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
                int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

                if (publisherId == userId || (ownerRestaurantId != null && ownerRestaurantId == reviewRestaurantId))
                {
                    return await reviewRepository.GetReview(reviewId);
                }

                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező értékelés megtekintése korátozva van.");
            }
            catch(ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
            }
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId)
        {
            string userId = userRepository.GetCurrentUserId();
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId)
                || (ownerRestaurantId != null && ownerRestaurantId == restaurantId))
            {
                return await reviewRepository.GetRestaurantReviews(restaurantId);
            }

            return new List<ReviewDto>();
        }

        public async Task<ReviewDto> AddReviewToRestaurant(int restaurantId, CreateReviewDto review)
        {
            try
            {
                string userId = userRepository.GetCurrentUserId();
                return await reviewRepository.AddReviewToRestaurant(userId, restaurantId, review);
            }
            catch(ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status400BadRequest, ae.Message);
            }
        }

        public async Task DeleteReview(int reviewId)
        {
            try
            {
                string userId = userRepository.GetCurrentUserId();
                string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
                int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
                int reviewRestaurantId = await reviewRepository.GetRestaurantIdReviewBelongTo(reviewId);

                if (publisherId == userId || (ownerRestaurantId != null && ownerRestaurantId == reviewRestaurantId))
                {
                    await reviewRepository.DeleteReview(reviewId);
                }

                throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                        "A megadott azonosítóval rendelkező értékelés törléséhez nincs jogosultságod.");
            }
            catch (ArgumentException ae)
            {
                throw new ProblemDetailsException(StatusCodes.Status404NotFound, ae.Message);
            }
        }
    }
}
