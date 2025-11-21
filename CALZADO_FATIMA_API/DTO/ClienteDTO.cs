namespace CALZADO_FATIMA_API.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string? DireccionCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? EmailCliente { get; set; }
    }
}
