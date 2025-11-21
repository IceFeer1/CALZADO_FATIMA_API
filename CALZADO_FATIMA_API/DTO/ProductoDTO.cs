namespace CALZADO_FATIMA_API.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string? DescripcionProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int StockProducto { get; set; }
    }
}
