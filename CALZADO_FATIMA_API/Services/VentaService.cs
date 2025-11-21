using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Services
{
    public class VentaService
    {
        private readonly VentaDAO _dao;

        public VentaService(VentaDAO dao) => _dao = dao;

        public Task<List<Venta>> ObtenerVentasAsync() => _dao.ObtenerTodasAsync();

        public Task<Venta?> ObtenerVentaAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearVentaAsync(Venta venta)
        {
            if (venta.IdCliente <= 0)
                throw new ArgumentException("La venta debe estar asociada a un cliente válido.");

            await _dao.CrearAsync(venta);
        }

        public Task ActualizarVentaAsync(Venta venta) => _dao.ActualizarAsync(venta);

        public Task EliminarVentaAsync(int id) => _dao.EliminarAsync(id);
    }
}
