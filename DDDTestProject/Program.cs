using DDDTestProject.Application.Interfaces;
using DDDTestProject.Application.Services;
using DDDTestProject.Domain.Interfaces;
using DDDTestProject.Infrastructure.Context;
using DDDTestProject.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// MongoDbContext i�in ba�lant� stringini almak ve servisi eklemek
builder.Services.AddSingleton<MongoDbContext>();  // MongoDbContext'i singleton olarak ekliyoruz

// Repository'leri DI container'a eklemek
builder.Services.AddScoped<IProductRepository, ProductRepository>();  // ProductRepository'nin DI kayd�
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  // CategoryRepository'nin DI kayd�

// Servisleri DI container'a eklemek
builder.Services.AddScoped<IProductService, ProductService>();  // ProductService'nin DI kayd�
builder.Services.AddScoped<ICategoryService, CategoryService>();  // CategoryService'nin DI kayd�

// MVC API kullanaca��m�z i�in MVC servisini ekliyoruz
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Swagger servisini ekliyoruz

var app = builder.Build();

// E�er geli�tirme ortam�ndaysak, hata sayfas�n� g�ster
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();  // Swagger'� etkinle�tir
    app.UseSwaggerUI();  // Swagger UI'yi etkinle�tir
}

app.UseRouting();

// API controller'lar�n� y�nlendir
app.MapControllers();

app.Run();