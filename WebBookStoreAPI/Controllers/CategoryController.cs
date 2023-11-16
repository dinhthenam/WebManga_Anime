using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace WebBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {



        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            return Ok(_categoryRepository.GetAllCategories());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPost]
        public ActionResult<int> CreateCategory(Category category)
        {
            var id = _categoryRepository.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id, category });
        }

        [HttpPut("{id}")]
            public IActionResult UpdateCategory(int id, Category category)
            {
                if (id != category.Category_Id)
                    return BadRequest();

                _categoryRepository.UpdateCategory(category);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteCategory(int id)
            {
                var category = _categoryRepository.GetCategoryById(id);
                if (category == null)
                    return NotFound();

                _categoryRepository.DeleteCategory(id);
                return NoContent();
            }
        }
    }

