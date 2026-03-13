using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCrud.Data;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{

    [Route("api/[controller]")]     // Define la ruta base. Como el controller se llama ProductosController, la ruta es /api/productos. [controller] reemplaza automáticamente por el nombre del controller sin la palabra Controller
    [ApiController]                 // Le dice a ASP.NET Core que esta clase es un controller de API. Los controllers de Web API derivan de ControllerBase
    public class ProductosController : ControllerBase   // Se hereda de ControllerBase, que es la base típica para APIs sin vistas 
    {
        private readonly AppDbContext _context; // Campo privado. Se guarda el contexto para usarlo en todos los métodos

        public ProductosController(AppDbContext context) // Constructor. ASP.NET Core inyecta el AppDbContext automáticamente
        {
            _context = context;
        }

        // Metodo GET de todos. Cuando llega GET /api/productos, devuelve todos los productos
        [HttpGet]   //indica que responde a GET
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()    // ActionResult<IEnumerable<Producto>> porque devuelve una lista o una respuesta HTTP
        {
            return await _context.Productos.ToListAsync();
        }

        // Metodo GET por id
        [HttpGet("{id}")] // Responde a GET /api/productos/5. Busca por id. Si no existe devuelve HTTP 404
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // Metodo POST. Responde a POST /api/productos. Recibe un producto en el body JSON, lo agrega y guarda cambios
        [HttpPost]
        public async Task<ActionResult<Producto>> Producto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // CreatedAtAction Devuelve 201 Created y además informa cómo obtener el recurso recién creado
            return CreatedAtAction(nameof(GetProducto), new { producto.Id }, producto);
        }

        // Metodo PUT. Responde a PUT /api/productos/5. Actualiza un producto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            // Si el id de la URL no coincide con el del objeto, se devuelve 400 Bad Request
            if (id != producto.Id)
            {
                return BadRequest();
            }

            // Marcar entidad como modificada. Le indica a EF Core que ese objeto debe actualizarse en la base
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // Se captura por si ocurre un problema al actualizar, por ejemplo si el registro ya no existe
            {
                if (!ProductoExiste(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // Metodo DELETE. Responde a DELETE /api/productos/5. Busca el producto, y si existe lo elimina
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExiste(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
