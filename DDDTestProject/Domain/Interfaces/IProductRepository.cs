using DDDTestProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DDDTestProject.Domain.Interfaces
{
    public interface IProductRepository
    {
        // Tüm ürünleri almak için bir metot
        Task<IEnumerable<Product>> GetAllAsync();

        // ID'ye göre bir ürün almak için bir metot
        Task<Product> GetByIdAsync(string id);

        // Yeni bir ürün eklemek için bir metot
        Task AddAsync(Product product);

        // Bir ürünü güncellemek için bir metot
        Task UpdateAsync(Product product);

        // Bir ürünü silmek için bir metot
        Task DeleteAsync(string id);
    }
}
