using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return await dbContext.Entry(dbReview).ToReviewDto();
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviews(int restaurantId)
        {
            return await dbContext.Reviews
                .Where(r => r.RestaurantId == restaurantId)
                .ToReviewDtoList();
        }

        public async Task<IReadOnlyCollection<ReviewDto>> GetGuestReviews(string guestId)
        {
            return await dbContext.Reviews
                .Where(r => r.UserId == guestId)
                .ToReviewDtoList();
        }

        public async Task<ReviewDto> AddReviewToRestaurant(string userId, int restaurantId, CreateReviewDto review)
        {
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            var dbUser = (await dbContext.Users
                                .SingleOrDefaultAsync(u => u.Id == userId))
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

        public async Task DeleteReview(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            dbContext.Reviews.Remove(dbReview);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetPubliserUserId(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return dbReview.UserId;
        }

        public async Task<int> GetRestaurantIdReviewBelongTo(int reviewId)
        {
            var dbReview = (await dbContext.Reviews
                                .SingleOrDefaultAsync(r => r.Id == reviewId))
                                .CheckIfReviewNull();

            return dbReview.RestaurantId;
        }

    }

    internal static class ReviewRepositoryExtensions
    {
        public static async Task<IReadOnlyCollection<ReviewDto>> ToReviewDtoList(this IQueryable<Review> reviews)
        {
            return await reviews
                    .Include(r => r.User)
                    .Include(r => r.Restaurant)
                    .Select(r => new ReviewDto(r)).ToListAsync();
        }

        public static async Task<ReviewDto> ToReviewDto(this EntityEntry<Review> review)
        {
            await review.Reference(r => r.User).LoadAsync();
            await review.Reference(r => r.Restaurant).LoadAsync();
            return new ReviewDto(review.Entity);
        }

        public static Review CheckIfReviewNull(this Review review,
            string errorMessage = "Az értékelés nem található.")
        {
            if (review == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return review;
        }
    }
}
