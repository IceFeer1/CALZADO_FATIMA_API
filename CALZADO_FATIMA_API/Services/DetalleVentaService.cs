using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class DetalleVentaService
    {
        private readonly DetalleVentaDAO _dao;

        public DetalleVentaService(DetalleVentaDAO dao) => _dao = dao;

        public Task<List<DetalleVenta>> ObtenerDetallesAsync() => _dao.ObtenerTodosAsync();

        public Task<DetalleVenta?> ObtenerDetalleAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearDetalleAsync(DetalleVenta detalle)
        {
            if (detalle.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");


            await _dao.CrearAsync(detalle);
        }

        public Task ActualizarDetalleAsync(DetalleVenta detalle) => _dao.ActualizarAsync(detalle);

        public Task EliminarDetalleAsync(int id) => _dao.EliminarAsync(id);
    }
}
