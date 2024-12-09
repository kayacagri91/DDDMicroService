using DDDTestProject.Domain.Entities;

namespace DDDTestProject.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(); // Tüm kategorileri getiren metod
        Task<Category> GetCategoryByIdAsync(string categoryId); // ID'ye göre kategori getiren metod
        Task CreateCategoryAsync(Category category); // Yeni kategori ekleyen metod
        Task UpdateCategoryAsync(Category category); // Kategori güncelleyen metod
        Task DeleteCategoryAsync(string categoryId); // Kategori silen metod
    }
}
