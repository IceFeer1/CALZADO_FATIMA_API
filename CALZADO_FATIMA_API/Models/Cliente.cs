namespace CALZADO_FATIMA_API.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;
        public string? DireccionCliente { get; set; }
        public string? TelefonoCliente { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();


    }
}
