using eApp.Models;
using eApp.Repositories;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> AddReviewAsync(int productId, Review review)
        {
            review.ProductId = productId;

            return await _reviewRepository.AddReviewAsync(review);
        }

        public Task<ICollection<Review>> GetReviewsFromProduct(int productId)
        {
            return _reviewRepository.GetAllReviewsAsync(productId);
        }
    }
}
