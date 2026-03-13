using Microsoft.EntityFrameworkCore;
using WebApiCrud.Data;

var builder = WebApplication.CreateBuilder(args); // Crea el constructor principal de la aplicacion

// Agrega servicios al container. Registra dependencias

builder.Services.AddControllers(); // Habilita controllers

// Se registra el contexto en el contenedor de dependencias
// Esto permite que luego ASP.NET Core lo inyecte automáticamente en el controller
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"))); // Lee la cadena desde appsettings.json

builder.Services.AddEndpointsApiExplorer(); // Permite que Swagger descubra los endpoints
builder.Services.AddSwaggerGen(); // Genera la documentación OpenAPI/Swagger

var app = builder.Build(); // Construye la app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Fuerza HTTPS

app.UseAuthorization(); // Sistema de autorización

app.MapControllers(); // Mapea endpoints

app.Run(); // Inicia el servidor
