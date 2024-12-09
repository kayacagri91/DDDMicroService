namespace DDDTestProject.Application.DTOs
{
    public class ProductDto
    {
        // ProductDto sınıfı, dışarıya gönderilecek olan ürün bilgilerini içerir.
        public string Id { get; set; } // Ürün ID'si
        public string Name { get; set; } // Ürün adı
        public decimal Price { get; set; } // Ürün fiyatı
        public int Stock { get; set; } // Ürün stok durumu
        public string Category { get; set; } // Ürünün ait olduğu kategori
    }
}
