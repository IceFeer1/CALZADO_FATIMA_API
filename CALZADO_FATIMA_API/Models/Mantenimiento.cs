namespace CALZADO_FATIMA_API.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public Producto Producto { get; set; } = null!;
    }
}
