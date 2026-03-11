var builder = WebApplication.CreateBuilder(args); //Inicializa la aplicación

// Agrega servicios al container. Registra dependencias

builder.Services.AddControllers(); // Habilita controllers

builder.Services.AddOpenApi();

var app = builder.Build(); // Construye la app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); // Fuerza HTTPS

app.UseAuthorization(); // Sistema de autorización

app.MapControllers(); // Mapea endpoints

app.Run(); // Inicia el servidor
