using eApp.Models;
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
        public async Task<ActionResult<ICollection<Product>>> GetProducts()
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

        [HttpGet("search")]
        public async Task<ActionResult<ICollection<Product>>> GetProductsBySearchValue([FromQuery] string searchValue)
        {
            var products = await _productService.GetProductsBySearchValue(searchValue);
            return Ok(products);
        }
    }
}
