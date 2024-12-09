using DDDTestProject.Application.Interfaces;
using DDDTestProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService; // ProductService bağımlılığı

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync(); // Tüm ürünleri al
            return Ok(products);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id); // ID'ye göre ürün al
            if (product == null)
            {
                return NotFound(); // Ürün bulunamadıysa 404 döndür
            }
            return Ok(product); // Ürünü döndür
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProductAsync(product); // Yeni ürün oluştur
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product); // 201 döndür ve ürünün detaylarını ekle
        }

        // PUT api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(); // ID uyuşmazsa 400 döndür
            }

            await _productService.UpdateProductAsync(product); // Ürünü güncelle
            return NoContent(); // Güncelleme başarılıysa 204 döndür
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id); // Ürünü sil
            return NoContent(); // Silme işlemi başarılıysa 204 döndür
        }
    }
}
