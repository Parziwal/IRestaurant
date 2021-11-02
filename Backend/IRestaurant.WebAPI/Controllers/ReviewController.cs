using IRestaurant.BL.Managers;
using IRestaurant.DAL.DTO.Reviews;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRestaurant.WebAPI.Controllers
{
    /// <summary>
    /// A étteremek értékeléseinek lekérdezése, új értékelés hozzáadása és a meglévő törlése.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewManager reviewManager;

        public ReviewController(ReviewManager reviewManager)
        {
            this.reviewManager = reviewManager;
        }

        /// <summary>
        /// A megadott azonosítójú rendelés lekérése.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        /// <returns>Az értékelés adatai.</returns>
        [AllowAnonymous]
        [HttpGet("{reviewId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewDto>> GetReview(int reviewId)
        {
            return await reviewManager.GetReview(reviewId);
        }

        /// <summary>
        /// A megadott étteremhez tartozó értékelések lekérése.
        /// </summary>
        /// <param name="restaurantId">Az étterem azonosítója.</param>
        /// <returns>Az étteremhez tartozó értékelések listája.</returns>
        [AllowAnonymous]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<ReviewDto>> GetRestraurantReviewList(int restaurantId)
        {
            return await reviewManager.GetRestaurantReviewList(restaurantId);
        }

        /// <summary>
        /// Az aktuális felhasználóhoz tartozó étterem értékeléseinek lekérése.
        /// </summary>
        /// <returns>Az aktuális felhasználó éttermének értékelései.</returns>
        [Authorize(Policy = UserRoles.Restaurant)]
        [HttpGet("restaurant/myrestaurant")]
        public async Task<IEnumerable<ReviewDto>> GetMyRestraurantReviewList()
        {
            return await reviewManager.GetMyRestaurantReviewList();
        }

        /// <summary>
        /// Az aktuális vendég által írt értékelések lekérése.
        /// </summary>
        /// <returns>Az aktuális vendég értékelései.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("myreviews")]
        public async Task<IEnumerable<ReviewDto>> GetCurrentGuestReviewList()
        {
            return await reviewManager.GetCurrentGuestReviewList();
        }

        /// <summary>
        /// Értékelés létrehozása az aktuális vendég által a megadott adatok alapján.
        /// </summary>
        /// <param name="review">A lérehozandó értékelés adatai.</param>
        /// <returns>A létrehozott értékelés.</returns>
        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDto>> AddReviewToRestaurant([FromBody] CreateReviewDto review)
        {
            var createdReview = await reviewManager.AddReviewToRestaurant(review);
            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
        }

        /// <summary>
        /// A megadott azonosítójú értékelés törlése.
        /// </summary>
        /// <param name="reviewId">Az értékelés azonosítója.</param>
        [HttpDelete("{reviewId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            await reviewManager.DeleteReview(reviewId);
            return NoContent();
        }
    }
}
