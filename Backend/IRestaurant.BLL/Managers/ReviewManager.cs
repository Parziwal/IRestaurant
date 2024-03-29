﻿using Hellang.Middleware.ProblemDetails;
using IRestaurant.BLL.Extensions;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.BLL.Managers
{
    /// <summary>
    /// Az értékelésekkel kapcsolatos műveletek, mint adat lekérés, módosítás és törlés szabályzásáért felelős.
    /// </summary>
    public class ReviewManager
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContext;

        public ReviewManager(IReviewRepository reviewRepository,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IHttpContextAccessor httpContext)
        {
            this.reviewRepository = reviewRepository;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.httpContext = httpContext;
        }

        /// <summary>
        /// A megadott azonosítójú értékelés lekérése, ha az értékeléshez tartozó étterem elérhető,
        /// vagy az aktuális felhasználó írta az értékelést, vagy az aktuális felhasználó az értékeléshez
        /// tartozó étterem tulajdonosa.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        /// <returns>Az értékelés adatai.</returns>
        public async Task<ReviewDto> GetReview(int reviewId)
        {
            int reviewRestaurantId = await reviewRepository.GetRestaurantIdReviewBelongTo(reviewId);

            if (await restaurantRepository.IsRestaurantAvailableForUsers(reviewRestaurantId))
            {
                return await reviewRepository.GetReview(reviewId);
            }

            string userId = httpContext.GetCurrentUserId();
            string publisherId = await reviewRepository.GetPubliserUserId(reviewId);
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;

            if (publisherId == userId || ownerRestaurantId == reviewRestaurantId)
            {
                return await reviewRepository.GetReview(reviewId);
            }

            throw new ProblemDetailsException(StatusCodes.Status400BadRequest,
                "A megadott azonosítóval rendelkező értékelés megtekintése korlátozva van.");
        }

        /// <summary>
        /// A megadott étteremhez tartozó értékelések lekérése, ha az értékeléshez tartozó étterem elérhető,
        /// vagy az aktuális felhasználó az értékeléshez tartozó étterem tulajdonosa.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étteremhez tartozó értékelések listája.</returns>
        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviewList(int restaurantId)
        {
            if (await restaurantRepository.IsRestaurantAvailableForUsers(restaurantId))
            {
                return await reviewRepository.GetRestaurantReviewList(restaurantId);
            }

            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.UserHasRestaurant(userId) ? await userRepository.GetMyRestaurantId(userId) : -1;

            if (restaurantId == ownerRestaurantId)
            {
                return await reviewRepository.GetRestaurantReviewList(restaurantId);
            }

            return new List<ReviewDto>();
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem értékeléseinek lekérése.
        /// </summary>
        /// <returns>Az aktuális felhasználó éttermének értékelései.</returns>
        public async Task<IReadOnlyCollection<ReviewDto>> GetMyRestaurantReviewList()
        {
            string userId = httpContext.GetCurrentUserId();
            int ownerRestaurantId = await userRepository.GetMyRestaurantId(userId);

            return await GetRestaurantReviewList(ownerRestaurantId);
        }

        /// <summary>
        /// Az aktuális vendég által írt értékelések lekérése.
        /// </summary>
        /// <returns>Az aktuális vendég értékelései.</returns>
        public async Task<IReadOnlyCollection<ReviewDto>> GetCurrentGuestReviewList()
        {
            string userId = httpContext.GetCurrentUserId();
            return await reviewRepository.GetGuestReviewList(userId);
        }

        /// <summary>
        /// Értékelés létrehozása az aktuális vendég által a megadott adatok alapján.
        /// </summary>
        /// <param name="review">A létrehozandó értékelés adatai.</param>
        /// <returns>A létrehozott értékelés adatai.</returns>
        public async Task<ReviewDto> AddReviewToRestaurant(CreateReviewDto review)
        {
            string userId = httpContext.GetCurrentUserId();
            return await reviewRepository.AddReviewToRestaurant(userId, review);
        }

        /// <summary>
        /// A megadott azonosítójú értékelés törlése, ha az aktuális felhasználó az értékelés publikálója.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        public async Task DeleteReview(int reviewId)
        {
            string userId = httpContext.GetCurrentUserId();
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
