using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Extensions
{
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
