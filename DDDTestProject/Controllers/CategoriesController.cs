using DDDTestProject.Application.Interfaces;
using DDDTestProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; // CategoryService bağımlılığı

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(); // Tüm kategorileri al
            return Ok(categories);
        }

        // GET api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id); // ID'ye göre kategori al
            if (category == null)
            {
                return NotFound(); // Kategori bulunamadıysa 404 döndür
            }
            return Ok(category); // Kategoriyi döndür
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            await _categoryService.CreateCategoryAsync(category); // Yeni kategori oluştur
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category); // 201 döndür ve kategorinin detaylarını ekle
        }

        // PUT api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(string id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest(); // ID uyuşmazsa 400 döndür
            }

            await _categoryService.UpdateCategoryAsync(category); // Kategoriyi güncelle
            return NoContent(); // Güncelleme başarılıysa 204 döndür
        }

        // DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id); // Kategoriyi sil
            return NoContent(); // Silme işlemi başarılıysa 204 döndür
        }

    }
}
