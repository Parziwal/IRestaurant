using IRestaurant.DAL.CustomExceptions;
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
            var dbReview = await dbContext.Reviews
                .Include(r => r.User)
                .SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            return dbReview.GetReview();
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId)
        {
            return await dbContext.Reviews
                .Include(r => r.User)
                .Where(r => r.RestaurantId == restaurantId).GetReviews();
        }

        public async Task<IReadOnlyCollection<GuestReviewDto>> GetGuestReviews(string guestId)
        {
            return await dbContext.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .Where(r => r.UserId == guestId).GetGuestReviews();
        }

        public async Task<ReviewDto> AddReviewToRestaurant(string userId, int restaurantId, CreateReviewDto review)
        {
            var dbRestaurant = await dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (dbRestaurant == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező étterem nem létezik.");
            }

            var dbUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (dbUser == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval felhasználó nem létezik.");
            }

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

            return dbReview.GetReview();
        }

        public async Task<ReviewDto> DeleteReview(int reviewId)
        {
            var dbReview = await dbContext.Reviews
                .Include(r => r.User)
                .SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező értékelés nem létezik.");
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
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező értékelés nem létezik.");
            }

            return dbReview.UserId;
        }

        public async Task<int> GetRestaurantIdReviewBelongTo(int reviewId)
        {
            var dbReview = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (dbReview == null)
            {
                throw new EntityNotFoundException("A megadott azonosítóval rendelkező értékelés nem létezik.");
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

        public static async Task<IReadOnlyCollection<GuestReviewDto>> GetGuestReviews(this IQueryable<Review> review)
        {
            return await review.Select(r => GetGuestReview(r)).ToListAsync();
        }

        public static GuestReviewDto GetGuestReview(this Review review)
        {
            return new GuestReviewDto(review, review.Restaurant);
        }
    }
}
