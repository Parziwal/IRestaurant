﻿using IRestaurant.DAL.DTO.Reviews;
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
        private readonly IHttpContextAccessor accessor;
        public ReviewManager(IReviewRepository reviewRepository,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IHttpContextAccessor accessor)
        {
            this.reviewRepository = reviewRepository;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.accessor = accessor;
        }

        public async Task<ReviewDto> GetReview(int reviewId)
        {
            int? reviewRestaurantId = await reviewRepository.GetRestaurantIdOrNullReviewBelongTo(reviewId);

            if (reviewRestaurantId != null && await restaurantRepository.IsRestaurantAvailableForUsers((int)reviewRestaurantId))
            {
                return await reviewRepository.GetReview(reviewId);
            }

            var userId = accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (publisherId == userId || (ownerRestaurantId != null && ownerRestaurantId == reviewRestaurantId))
            {
                return await reviewRepository.GetReview(reviewId);
            }

            return null;
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId)
        {
            var userId = accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId)
                || ownerRestaurantId == restaurantId)
            {
                return await reviewRepository.GetRestaurantReviews(restaurantId);
            }
            return new List<ReviewDto>();
        }

        public async Task<ReviewDto> AddReviewToRestaurant(int restaurantId, CreateReviewDto review)
        {
            var userId = accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return await reviewRepository.AddReviewToRestaurant(userId, restaurantId, review);
        }

        public async Task<ReviewDto> DeleteReview(int reviewId)
        {
            var userId = accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
            int? ownerRestaurantId = await userRepository.GetUserRestaurantIdOrNull(userId);
            int? reviewRestaurantId = await reviewRepository.GetRestaurantIdOrNullReviewBelongTo(reviewId);

            if (publisherId == userId || (ownerRestaurantId != null && ownerRestaurantId == reviewRestaurantId))
            {
                return await reviewRepository.DeleteReview(reviewId);
            }

            return null;
        }
    }
}
