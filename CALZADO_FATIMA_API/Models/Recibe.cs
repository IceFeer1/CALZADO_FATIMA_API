namespace CALZADO_FATIMA_API.Models
{
    public class Recibe
    {
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaRecibo { get; set; }

        public Proveedor Proveedor { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
    }
}
