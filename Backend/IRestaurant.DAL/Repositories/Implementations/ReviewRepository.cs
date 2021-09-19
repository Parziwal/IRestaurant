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

    /// <summary>
    /// Az értékeléshez kapcsolódó extension metódusok.
    /// </summary>
    internal static class ReviewRepositoryExtensions
    {
        /// <summary>
        /// A értékelés típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="reviews">Értékelés típusú lekérdezés.</param>
        /// <returns>Az értékelések adatait tartalmazó adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<ReviewDto>> ToReviewDtoList(this IQueryable<Review> reviews)
        {
            return await reviews
                    .Include(r => r.User)
                    .Include(r => r.Restaurant)
                    .Select(r => new ReviewDto(r)).ToListAsync();
        }

        /// <summary>
        /// A értékelés modell osztály átalakítása részletes adatokat tartalmazó adatátviteli objektummá.
        /// </summary>
        /// <param name="review">Értékelés typusú entitás.</param>
        /// <returns>Az értékelés adatait tartalmazó adatátviteli objektum.</returns>
        public static async Task<ReviewDto> ToReviewDto(this EntityEntry<Review> review)
        {
            await review.Reference(r => r.User).LoadAsync();
            await review.Reference(r => r.Restaurant).LoadAsync();
            return new ReviewDto(review.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott értékelés típusú modell osztáy null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="review">Értékelés típusú modell osztály.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Értékelés típusú modell osztály.</returns>
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
