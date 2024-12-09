using DDDTestProject.Domain.Entities;
using MongoDB.Driver;
using DDDTestProject.Domain.Entities;

namespace DDDTestProject.Infrastructure.Context
{
    public class MongoDbContext
    {
        // MongoDB veritabanına bağlanmak için MongoClient
        private readonly IMongoDatabase _database;

        // Constructor: IConfiguration üzerinden bağlantı stringini alır ve MongoDB'ye bağlanır
        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            _database = client.GetDatabase("ProductManagementDB"); // Veritabanı adı
        }

        // Veritabanında Product koleksiyonuna erişim sağlayacak özellik
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");

        // Veritabanında Category koleksiyonuna erişim sağlayacak özellik
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
    }
}
