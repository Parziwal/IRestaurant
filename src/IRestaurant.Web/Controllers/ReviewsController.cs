using IRestaurant.BL;
using IRestaurant.DAL.DTO.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRestaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewManager reviewManager;
        public ReviewsController(ReviewManager reviewManager)
        {
            this.reviewManager = reviewManager;
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewDto>> GetById(int reviewId)
        {
            return await reviewManager.GetReview(reviewId);
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<ReviewDto>> GetRestraurantReviews(int restaurantId)
        {
            return await reviewManager.GetRestaurantReviews(restaurantId);
        }

        [Authorize(Roles = "Guest")]
        [HttpPost("restaurant/{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDto>> AddReviewToRestaurant(int restaurantId, [FromBody] CreateReviewDto review)
        {
            var createdReview = await reviewManager.AddReviewToRestaurant(restaurantId, review);
            return CreatedAtAction(nameof(GetById), new { id = createdReview }, createdReview);
        }

        [Authorize(Roles = "Restaurant,Guest")]
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
