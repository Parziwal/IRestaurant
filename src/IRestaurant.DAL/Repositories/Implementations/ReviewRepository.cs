using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ReviewDto> GetReview(int reviewId)
        {
            return (await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId))?.GetReview();
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId)
        {
            return await dbContext.Reviews.Where(r => r.RestaurantId == restaurantId).GetReviews();
        }
        public async Task<ReviewDto> AddReviewToRestaurant(string userId, int restaurantId, CreateReviewDto review)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new ArgumentException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            var dbReview = new Review {
                Title = review.Title,
                Description = review.Description,
                Rating = review.Rating,
                UserId = userId,
                Restaurant = dbRestaurant
            };

            await dbContext.AddAsync(dbReview);
            await dbContext.SaveChangesAsync();

            return dbReview.GetReview();
        }

        public async Task<ReviewDto> DeleteReview(int reviewId)
        {
            var dbReview = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new ArgumentException("A megadott azonosítóval rendelkező értékelés nem létezik.");
            }

            dbContext.Reviews.Remove(dbReview);
            await dbContext.SaveChangesAsync();

            return dbReview.GetReview();
        }

        public async Task<string> GetPubliserUserId(int reviewId)
        {
            var dbReview = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new ArgumentException("A megadott azonosítóval rendelkező értékelés nem létezik.");
            }

            return dbReview.UserId;
        }

        public async Task<int> GetRestaurantIdReviewBelongTo(int reviewId)
        {
            var dbReview = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new ArgumentException("A megadott azonosítóval rendelkező értékelés nem létezik.");
            }

            return dbReview.RestaurantId;
        }

    }

    internal static class ReviewRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<ReviewDto>> GetReviews(this IQueryable<Review> review)
        {
            return await review.Select(r => GetReview(r)).ToListAsync();
        }

        public static ReviewDto GetReview(this Review review)
        {
            return new ReviewDto(review, review.User);
        }
    }
}
