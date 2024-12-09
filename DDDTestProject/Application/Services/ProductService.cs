using DDDTestProject.Application.Interfaces;
using DDDTestProject.Domain.Entities;
using DDDTestProject.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDTestProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; // ProductRepository bağımlılığı

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync(); // Repository'den tüm ürünleri getir
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _productRepository.GetByIdAsync(productId); // Repository'den ürün ID'ye göre getir
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product); // Yeni ürünü repository'ye ekle
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product); // Ürünü repository'de güncelle
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productRepository.DeleteAsync(productId); // Ürünü repository'den sil
        }
    }
}
