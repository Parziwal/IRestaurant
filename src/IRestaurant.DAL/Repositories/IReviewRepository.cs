using IRestaurant.DAL.DTO.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    /// <summary>
    /// Az étteremhez tartozó értékelések kezeléséért felelős.
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// A megadott azonosítóhoz tartaozó értékelés lekérdezése.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        /// <returns>Az értékelés adatai.</returns>
        Task<ReviewDto> GetReview(int reviewId);

        /// <summary>
        /// A megadott étteremhez tartozó értékelések lekérése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az éttermhez tartozó értékelések listája.</returns>
        Task<IReadOnlyCollection<ReviewDto>> GetRestaurantReviewList(int restaurantId);

        /// <summary>
        /// A vendéghez tartozó érékelések lekérdezése.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <returns>Az vendéghez tartozó értékelések listája</returns>
        Task<IReadOnlyCollection<ReviewDto>> GetGuestReviewList(string guestId);

        /// <summary>
        /// Felhasználói értékelés hozzáadása a megadott éttermehez.
        /// </summary>
        /// <param name="guestId">A vendég azonosítója.</param>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <param name="review">A létrehozandó értékelés adatai.</param>
        /// <returns>A létrehozott értékelés adatai.</returns>
        Task<ReviewDto> AddReviewToRestaurant(string guestId, int restaurantId, CreateReviewDto review);

        /// <summary>
        /// A megadott azonosítójú értékelés törlése.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        Task DeleteReview(int reviewId);

        /// <summary>
        /// Az értékelést publikáló felhasználó egyedi azonosítójának lekérdezése.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        /// <returns>Az egyedi felhasználói azonosító.</returns>
        Task<string> GetPubliserUserId(int reviewId);

        /// <summary>
        /// Az éttrem egyedi azonosítójának lekérése, amihez az értékelés tartozik.
        /// </summary>
        /// <param name="reviewId">Az értékelés egyedi azonosítója.</param>
        /// <returns>Az étterem egyedi azonosítója.</returns>
        Task<int> GetRestaurantIdReviewBelongTo(int reviewId);
    }
}
