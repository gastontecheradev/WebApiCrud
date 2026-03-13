CARACTERISTICAS IMPLEMENTADAS EN EL PROYECTO

- Proyecto Web API

- Modelo

- Contexto

- Conexión a SQL Server

- Controller CRUD

- Migración

- PruebaS con Swagger


ESTRUCTURA DEL PROYECTO

- Models/Producto.cs

- Data/AppDbContext.cs

- Controllers/ProductosController.cs

- Program.cs

- appsettings.json


PROCESO DE CREACIÓN DEL PROYECTO

1 - Instalar los paquetes NuGet

    - Install-Package Microsoft.EntityFrameworkCore.SqlServer
    - Install-Package Microsoft.EntityFrameworkCore.Tools

2 - Crear la carpeta Models

	- Dentro de la carpteta Models crear al clase Producto.cs

	namespace WebApiCrud.Models
    {
        public class Producto
        {
            public int Id { get; set; }

            public string Nombre { get; set; } = string.Empty;

            public decimal Precio { get; set; }

            public int Stock { get; set; }
        }
    }


3 - Crear el contexto de la base de datos

    - Crear la carpeta Data
    - Crear la clase AppDbContext.cs dentro de la carpeta Data

    using Microsoft.EntityFrameworkCore;
    using WebApiCrud.Models;

    namespace WebApiCrud.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Producto> Productos { get; set; }
        }
    }


4 - Configurar la conexion en appsettings.json

    "ConnectionStrings": {
        "ConexionSql": "Server=(localdb)\\MSSQLLocalDB;Database=WebApiCrudDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
      }



5 - Agregar configuracion en Program.cs

    using Microsoft.EntityFrameworkCore;
    using WebApiCrud.Data;

    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


6 - Crear la Carpeta Controllers
    
    - Crear la clase ProductosController.cs dentro de la carpeta Controllers