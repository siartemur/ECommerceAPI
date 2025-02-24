using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Services;
using ECommerceAPI.Services.Interfaces;
using ECommerceAPI.Mapping;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Veritabanı Bağlantısı
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// 🔹 Servis Katmanı (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductService>();

// 🔹 AutoMapper'ı Projeye Dahil Et
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 🔹 FluentValidation'ı Otomatik Kaydet
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// 🔹 MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// 🔹 Controller ve Swagger Ayarları
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerceAPI", Version = "v1" });
});

var app = builder.Build();

// 🔹 Ortam Kontrolleri (Swagger)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Middleware Pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
