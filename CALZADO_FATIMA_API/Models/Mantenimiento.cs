namespace CALZADO_FATIMA_API.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaMantenimiento { get; set; }
        public Producto Producto { get; set; } = null!;
    }
}
