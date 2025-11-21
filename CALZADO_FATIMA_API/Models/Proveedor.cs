namespace CALZADO_FATIMA_API.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } = string.Empty;
        public string? TelefonoProveedor { get; set; }

        public ICollection<Suministra> Suministros { get; set; } = new List<Suministra>();
        public ICollection<Recibe> Recepciones { get; set; } = new List<Recibe>(); 

    }
}
