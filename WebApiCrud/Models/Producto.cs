namespace WebApiCrud.Models
{
    // Entidad de negocio que se va a guardar en la base de datos
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = ""; // Evitar que empiece en null y tener un valor por defecto
        public decimal Precio { get; set; }
        public  int Stock { get; set; }
    }
}
