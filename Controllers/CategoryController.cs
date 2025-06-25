using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
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
        [HttpGet("searchValue")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<Category>>> GetCategoryBySearchValueAsync([FromQuery] string searchValue)
        {
            return Ok(await _categoryService.GetCategoriesBySearchValue(searchValue));
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveCategoryAsync(int categoryId)
        {
            await _categoryService.RemoveCategoryAsync(categoryId);

            return Ok(new { message = "Categoria Removida com Sucesso!" });
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateCategoryAsync(Category category, int categoryId)
        {
            await _categoryService.UpdateCategoryAsync(category, categoryId);
            return Ok(new { message = "Categoria Atualizada com Sucesso" });
        }

    }
}