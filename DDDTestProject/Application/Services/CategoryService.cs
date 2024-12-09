using DDDTestProject.Application.Interfaces;
using DDDTestProject.Domain.Entities;
using DDDTestProject.Domain.Interfaces;

namespace DDDTestProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository; // CategoryRepository bağımlılığı

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync(); // Repository'den tüm kategorileri getir
        }

        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId); // Repository'den kategori ID'ye göre getir
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category); // Yeni kategoriyi repository'ye ekle
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category); // Kategoriyi repository'de güncelle
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId); // Kategoriyi repository'den sil
        }
    }
}
