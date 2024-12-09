using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DDDTestProject.Domain.Entities
{
    public class Category
    {
        [BsonId]  // MongoDB'nin ID alanını işaret etmek için kullanılır
        [BsonRepresentation(BsonType.ObjectId)]  // ObjectId'yi string'e dönüştür
        public string Id { get; set; } // MongoDB'deki '_id' alanı, kategorinin benzersiz kimliği

        // Kategori adı
        [BsonElement("name")]
        public string Name { get; set; } // Kategorinin adı

        [BsonElement("description")]
        // Kategori açıklaması
        public string Description { get; set; } // Kategorinin açıklaması
    }
}
