namespace WinFormsApp1.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;
        public string? DireccionCliente { get; set; }
        public string? TelefonoCliente { get; set; }
    }
}
