namespace CALZADO_FATIMA_API.Models
{
    public class Suministra
    {
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaSuministro { get; set; }

        public Proveedor Proveedor { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
    }
}
