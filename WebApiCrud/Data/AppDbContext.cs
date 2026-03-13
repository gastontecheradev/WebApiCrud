using Microsoft.EntityFrameworkCore;
using WebApiCrud.Models;

namespace WebApiCrud.Data
{
    public class AppDbContext : DbContext // DbContext es la clase central de EF Core para trabajar con la base de datos
    {
        // Constructor. Recibe la configuración del contexto y se la pasa a la clase base
        // ASP.NET Core, usando inyección de dependencias, le entrega al contexto la configuración para conectarse a SQL Server
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
        // Representa la colección de productos en la base
        // clase Producto - tabla Productos
        // DbSet<Producto> - acceso a la tabla
        public DbSet<Producto> Productos { get; set; }
    }
}
