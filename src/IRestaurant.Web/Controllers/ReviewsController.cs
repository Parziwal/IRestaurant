using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewManager reviewManager;
        public ReviewsController(ReviewManager reviewManager)
        {
            this.reviewManager = reviewManager;
        }

        [AllowAnonymous]
        [HttpGet("{reviewId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReviewDto>> GetReview(int reviewId)
        {
            return await reviewManager.GetReview(reviewId);
        }

        [AllowAnonymous]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IEnumerable<ReviewDto>> GetRestraurantReviewList(int restaurantId)
        {
            return await reviewManager.GetRestaurantReviewList(restaurantId);
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpGet("myreviews")]
        public async Task<IEnumerable<ReviewDto>> GetCurrentGuestReviewList()
        {
            return await reviewManager.GetCurrentGuestReviewList();
        }

        [Authorize(Policy = UserRoles.Guest)]
        [HttpPost("restaurant/{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDto>> AddReviewToRestaurant(int restaurantId, [FromBody] CreateReviewDto review)
        {
            var createdReview = await reviewManager.AddReviewToRestaurant(restaurantId, review);
            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
        }

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
