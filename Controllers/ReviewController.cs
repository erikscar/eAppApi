using eApp.Models;
using eApp.Services;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ICollection<Review>>> GetReviewsFromProductAsync(int productId)
        {
            var reviews = await _reviewService.GetReviewsFromProduct(productId);
            return Ok(reviews);
        }

        [HttpPost("{productId}")]
        public async Task<ActionResult<Review>> CreateReviewAsync([FromBody] Review review, int productId)
        {
            await _reviewService.AddReviewAsync(productId, review);
            return Ok("Review Adicionada com Sucesso");
        }
    }
}
