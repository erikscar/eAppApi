using eApp.Models.DTOs;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DashboardService(
            IUserRepository userRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
        )
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<DashboardDTO>> GetLatestRecords()
        {
            var users = (await _userRepository.GetAllAsync()).Select(u => new DashboardDTO
            {
                Type = "Usuário",
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                CreatedAt = u.CreatedAt,
            });

            var products = (await _productRepository.GetAllAsync()).Select(p => new DashboardDTO
            {
                Type = "Produto",
                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt,
            });

            var categories = (await _categoryRepository.GetAllCategoriesAsync()).Select(
                c => new DashboardDTO
                {
                    Type = "Categoria",
                    Id = c.Id,
                    Name = c.Name,
                    CreatedAt = c.CreatedAt,
                }
            );

            return users
                .Concat(products)
                .Concat(categories)
                .OrderByDescending(data => data.CreatedAt)
                .ToList();
        }
    }
}
