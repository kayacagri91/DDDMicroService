using DDDTestProject.Domain.Entities;

namespace DDDTestProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(); // Tüm ürünleri getiren metod
        Task<Product> GetProductByIdAsync(string productId); // ID'ye göre ürün getiren metod
        Task CreateProductAsync(Product product); // Yeni ürün ekleyen metod
        Task UpdateProductAsync(Product product); // Ürün güncelleyen metod
        Task DeleteProductAsync(string productId); // Ürün silen metod
    }
}
