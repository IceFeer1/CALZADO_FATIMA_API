namespace CALZADO_FATIMA_API.DTO
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } = string.Empty;
        public string? DireccionProveedor { get; set; }
        public string? TelefonoProveedor { get; set; }
        public string? EmailProveedor { get; set; }
    }
}
