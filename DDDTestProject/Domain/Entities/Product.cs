using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DDDTestProject.Domain.Entities
{
    public class Product
    {
        [BsonId]  // MongoDB'nin ID alanını işaret etmek için kullanılır
        [BsonRepresentation(BsonType.ObjectId)]  // ObjectId'yi string'e dönüştür
        // MongoDB'nin benzersiz ID'si
        public string Id { get; set; } // MongoDB'deki '_id' alanı, ürünün benzersiz kimliği

        // Ürün adı
        [BsonElement("name")]
        public string Name { get; set; } // Ürünün adı

        // Ürün açıklaması
        [BsonElement("description")]
        public string Description { get; set; } // Ürünün kısa açıklaması

        // Ürün fiyatı
        [BsonElement("price")]
        public decimal Price { get; set; } // Ürün fiyatı (decimal kullanmak doğru olur)

        // Ürün stok durumu
        [BsonElement("stock")]
        public int Stock { get; set; } // Ürün stok miktarı

        // Ürünün hangi kategoriye ait olduğunu belirtir
        [BsonElement("category")]
        public string Category { get; set; } // Kategori adı, 'Categories' koleksiyonuna referans olur

        // Ürünün oluşturulma tarihi
        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } // Ürün ilk kez eklendiğinde bu tarih ayarlanır
    }
}