using eApp.Models;
using eApp.Models.DTOs;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProductsAsync());
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
           
            try
            {
                return Ok(await _productService.GetProductByIdAsync(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<ICollection<Product>>> GetProductsBySearchValue([FromQuery] string searchValue)
        {
           var products = await _productService.FilterProductsAsync(searchValue);
            return Ok(products);
        }

        [HttpGet("category")]
        public async Task<ActionResult<ICollection<Product>>> GetProductsByCategory([FromQuery] string category)
        {
            var products = await _productService.GetProductByCategory(category);
            return Ok(products);
        }
    }
}
