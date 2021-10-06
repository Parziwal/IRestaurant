using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Extensions;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    /// <summary>
    /// Az étteremhez tartozó értékelések lekéréséért és kezeléséért felelős.
    /// </summary>
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        ///  Az adatbázis inicializációja a konstruktorban.
        /// </summary>
        /// <param name="dbContext">Az adatbázis.</param>
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// A megadott azonosítóhoz tartaozó értékelés lekérdezése.
        /// Ha a megadott azonosítóval értékelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        /// <returns>Az értékelés adatai.</returns>
        public async Task<ReviewDto> GetReview(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return await dbContext.Entry(dbReview).ToReviewDto();
        }

        /// <summary>
        /// A megadott étteremhez tartozó értékelések lekérése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az éttermhez tartozó értékelések listája.</returns>
        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviewList(int restaurantId)
        {
            return await dbContext.Reviews
                .Where(r => r.RestaurantId == restaurantId)
                .ToReviewDtoList();
        }

        /// <summary>
        /// A vendéghez tartozó érékelések lekérdezése.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <returns>Az vendéghez tartozó értékelések listája</returns>
        public async Task<IReadOnlyCollection<ReviewDto>> GetGuestReviewList(string guestId)
        {
            return await dbContext.Reviews
                .Where(r => r.UserId == guestId)
                .ToReviewDtoList();
        }

        /// <summary>
        /// A megadott adatok alapján az értékelés létrehozása.
        /// Ha a megadott azonosítóval étterem vagy felhasználó nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója, aki az értékelést írta.</param>
        /// <param name="review">A létrehozandó értékelés adatai.</param>
        /// <returns>A létrehozott értékelés adatai.</returns>
        public async Task<ReviewDto> AddReviewToRestaurant(string guestId, CreateReviewDto review)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == review.RestaurantId))
                                    .CheckIfRestaurantNull();

            var dbUser = (await dbContext.Users
                                .SingleOrDefaultAsync(u => u.Id == guestId))
                                .CheckIfUserNull();

            var dbReview = new Review {
                Title = review.Title,
                Description = review.Description,
                CreatedAt = DateTime.Now,
                Rating = review.Rating,
                User = dbUser,
                Restaurant = dbRestaurant
            };

            await dbContext.AddAsync(dbReview);
            await dbContext.SaveChangesAsync();

            return await dbContext.Entry(dbReview).ToReviewDto();
        }

        /// <summary>
        /// A megadott azonosítójú értékelés törlése.
        /// Ha a megadott azonosítóval értékelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        public async Task DeleteReview(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            dbContext.Reviews.Remove(dbReview);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Az értékelést publikáló felhasználó egyedi azonosítójának lekérdezése.
        /// Ha a megadott azonosítóval értékelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        /// <returns>Az egyedi felhasználói azonosító.</returns>
        public async Task<string> GetPubliserUserId(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return dbReview.UserId;
        }

        /// <summary>
        /// Az éttrem egyedi azonosítójának lekérése, amihez az értékelés tartozik.
        /// Ha a megadott azonosítóval értékelés nem található, akkor kivételt dobunk.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        /// <returns>Az étterem egyedi azonosítója.</returns>
        public async Task<int> GetRestaurantIdReviewBelongTo(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return dbReview.RestaurantId;
        }

    }
}
