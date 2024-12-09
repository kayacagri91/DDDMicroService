using DDDTestProject.Domain.Entities;
using DDDTestProject.Domain.Interfaces;
using DDDTestProject.Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DDDTestProject.Infrastructure.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        // MongoDbContext üzerinden kategori koleksiyonuna erişilecek
        private readonly MongoDbContext _context;

        // Constructor: Dependency Injection ile MongoDbContext alınır
        public CategoryRepository(MongoDbContext context)
        {
            _context = context;
        }

        // Tüm kategorileri almak için metod
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.Find(_ => true).ToListAsync(); // MongoDB'den tüm kategorileri alıyoruz
        }

        // ID'ye göre bir kategoriyi almak için metod
        public async Task<Category> GetByIdAsync(string id)
        {
            return await _context.Categories.Find(category => category.Id == id).FirstOrDefaultAsync(); // MongoDB'den belirli ID'ye sahip kategoriyi alıyoruz
        }

        // Yeni bir kategori eklemek için metod
        public async Task AddAsync(Category category)
        {
            await _context.Categories.InsertOneAsync(category); // MongoDB'ye yeni kategori ekliyoruz
        }

        // Kategori güncellemek için metod
        public async Task UpdateAsync(Category category)
        {
            await _context.Categories.ReplaceOneAsync(c => c.Id == category.Id, category); // MongoDB'deki kategoriyi güncelliyoruz
        }

        // Kategori silmek için metod
        public async Task DeleteAsync(string id)
        {
            await _context.Categories.DeleteOneAsync(category => category.Id == id); // MongoDB'den kategoriyi siliyoruz
        }
    }
}
