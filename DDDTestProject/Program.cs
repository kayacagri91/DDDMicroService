using DDDTestProject.Application.Interfaces;
using DDDTestProject.Application.Services;
using DDDTestProject.Domain.Interfaces;
using DDDTestProject.Infrastructure.Context;
using DDDTestProject.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// MongoDbContext için baðlantý stringini almak ve servisi eklemek
builder.Services.AddSingleton<MongoDbContext>();  // MongoDbContext'i singleton olarak ekliyoruz

// Repository'leri DI container'a eklemek
builder.Services.AddScoped<IProductRepository, ProductRepository>();  // ProductRepository'nin DI kaydý
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  // CategoryRepository'nin DI kaydý

// Servisleri DI container'a eklemek
builder.Services.AddScoped<IProductService, ProductService>();  // ProductService'nin DI kaydý
builder.Services.AddScoped<ICategoryService, CategoryService>();  // CategoryService'nin DI kaydý

// MVC API kullanacaðýmýz için MVC servisini ekliyoruz
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Swagger servisini ekliyoruz

var app = builder.Build();

// Eðer geliþtirme ortamýndaysak, hata sayfasýný göster
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();  // Swagger'ý etkinleþtir
    app.UseSwaggerUI();  // Swagger UI'yi etkinleþtir
}

app.UseRouting();

// API controller'larýný yönlendir
app.MapControllers();

app.Run();