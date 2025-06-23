using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult<ICollection<Category>>> GetAllCategoriesAsync()
        {
            try
            {
                return Ok(await _categoryService.GetCategoriesAsync());
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}