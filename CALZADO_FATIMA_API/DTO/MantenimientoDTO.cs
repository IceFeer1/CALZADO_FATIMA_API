namespace CALZADO_FATIMA_API.DTO
{
    public class MantenimientoDTO
    {
        public int IdMantenimiento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaMantenimiento { get; set; }
        public int IdProducto { get; set; }
    }
}
