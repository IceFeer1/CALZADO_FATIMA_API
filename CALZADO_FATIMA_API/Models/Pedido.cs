namespace CALZADO_FATIMA_API.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdTipo { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaPedido { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public TipoPedido TipoPedido { get; set; } = null!;
        public EstadoPedido EstadoPedido { get; set; } = null!;
    }
}
