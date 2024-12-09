using DDDTestProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDTestProject.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        // Tüm kategorileri almak için bir metot
        Task<IEnumerable<Category>> GetAllAsync();

        // ID'ye göre bir kategori almak için bir metot
        Task<Category> GetByIdAsync(string id);

        // Yeni bir kategori eklemek için bir metot
        Task AddAsync(Category category);

        // Bir kategoriyi güncellemek için bir metot
        Task UpdateAsync(Category category);

        // Bir kategoriyi silmek için bir metot
        Task DeleteAsync(string id);
    }
}
