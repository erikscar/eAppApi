using eApp.Models;

namespace eApp.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetReviewsFromProduct(int productId);
        Task<Review> AddReviewAsync(int productId, Review review);
    }
}
