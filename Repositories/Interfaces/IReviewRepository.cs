using eApp.Models;

namespace eApp.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetAllReviewsAsync(int productId);
        Task<Review> AddReviewAsync(Review review);
    }
}
