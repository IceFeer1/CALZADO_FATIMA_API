namespace CALZADO_FATIMA_API.DTO
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
    }
}
