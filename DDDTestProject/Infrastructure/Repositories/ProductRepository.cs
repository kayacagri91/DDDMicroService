using DDDTestProject.Domain.Entities;
using DDDTestProject.Domain.Interfaces;
using DDDTestProject.Infrastructure.Context;
using MongoDB.Driver;

namespace DDDTestProject.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // MongoDbContext üzerinden ürün koleksiyonuna erişilecek
        private readonly MongoDbContext _context;

        // Constructor: Dependency Injection ile MongoDbContext alınır
        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        // Tüm ürünleri almak için metod
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Find(_ => true).ToListAsync(); // MongoDB'den tüm ürünleri alıyoruz
        }

        // ID'ye göre bir ürünü almak için metod
        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.Find(product => product.Id == id).FirstOrDefaultAsync(); // MongoDB'den belirli ID'ye sahip ürünü alıyoruz
        }

        // Yeni bir ürün eklemek için metod
        public async Task AddAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product); // MongoDB'ye yeni ürün ekliyoruz
        }

        // Ürün güncellemek için metod
        public async Task UpdateAsync(Product product)
        {
            await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product); // MongoDB'deki ürünü güncelliyoruz
        }

        // Ürün silmek için metod
        public async Task DeleteAsync(string id)
        {
            await _context.Products.DeleteOneAsync(product => product.Id == id); // MongoDB'den ürünü siliyoruz
        }
    }
}
