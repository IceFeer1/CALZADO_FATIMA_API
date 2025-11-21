namespace CALZADO_FATIMA_API.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioProducto { get; set; }
        public int IdTalla { get; set; }

        public ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
        public ICollection<Suministra> Suministros { get; set; } = new List<Suministra>();
        public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
        public ICollection<Recibe> Recepciones { get; set; } = new List<Recibe>();

    }
}
