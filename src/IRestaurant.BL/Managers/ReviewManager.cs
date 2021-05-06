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

namespace IRestaurant.BL.Managers
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
            int reviewRestaurantId = await reviewRepository.GetRestaurantIdReviewBelongTo(reviewId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(reviewRestaurantId))
            {
                return await reviewRepository.GetReview(reviewId);
            }

            string userId = userRepository.GetCurrentUserId();
            string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetOwnerRestaurantId(userId) : -1;

            if (publisherId == userId || ownerRestaurantId == reviewRestaurantId)
            {
                return await reviewRepository.GetReview(reviewId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező értékelés megtekintése korlátozva van.");
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviewList(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await reviewRepository.GetRestaurantReviewList(restaurantId);
            }

            string userId = userRepository.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetOwnerRestaurantId(userId) : -1;

            if (restaurantId == ownerRestaurantId)
            {
                return await reviewRepository.GetRestaurantReviewList(restaurantId);
            }

            return new List<ReviewDto>();
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetCurrentGuestReviewList()
        {
            string userId = userRepository.GetCurrentUserId();
            return await reviewRepository.GetGuestReviewList(userId);
        }

        public async Task<ReviewDto> AddReviewToRestaurant(int restaurantId, CreateReviewDto review)
        {
            string userId = userRepository.GetCurrentUserId();
            return await reviewRepository.AddReviewToRestaurant(userId, restaurantId, review);
        }

        public async Task DeleteReview(int reviewId)
        {
            string userId = userRepository.GetCurrentUserId();
            string publisherId = await reviewRepository.GetPubliserUserId(reviewId);

            if (publisherId == userId)
            {
                await reviewRepository.DeleteReview(reviewId);
                return;
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                    "A megadott azonosítóval rendelkező értékelés törléséhez nincs jogosultságod.");
        }
    }
}
