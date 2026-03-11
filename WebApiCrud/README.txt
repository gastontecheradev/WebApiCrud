ESTRUCTURA DEL PROYECTO

- Models/Producto.cs

- Data/AppDbContext.cs

- Controllers/ProductosController.cs

- Program.cs

- appsettings.json


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


