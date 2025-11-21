namespace CALZADO_FATIMA_API.DTO
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipo { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
