namespace WinFormsApp1.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioProducto { get; set; }
        public int IdTalla { get; set; }
    }
}
