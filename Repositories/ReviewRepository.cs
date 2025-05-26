using eApp.Data;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EAppContext _context;
        public ReviewRepository(EAppContext context)
        {
            _context = context;
        }
        public async Task<Review> AddReviewAsync(Review review)
        {
            await _context.AddAsync(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<ICollection<Review>> GetAllReviewsAsync(int productId)
        {
            return await _context.Reviews.Where(review => review.ProductId == productId).ToListAsync();
        }
    }
}
