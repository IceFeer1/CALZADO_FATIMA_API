using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Services
{
    public class SuministraService
    {
        private readonly SuministraDAO _dao;

        public SuministraService(SuministraDAO dao) => _dao = dao;

        public Task<List<Suministra>> ObtenerSuministrosAsync() => _dao.ObtenerTodosAsync();

        public Task<Suministra?> ObtenerSuministroAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearSuministroAsync(Suministra suministra)
        {
            if (suministra.IdProveedor <= 0 || suministra.IdProducto <= 0)
                throw new ArgumentException("Proveedor y producto deben ser válidos.");

            await _dao.CrearAsync(suministra);
        }

        public Task ActualizarSuministroAsync(Suministra suministra) => _dao.ActualizarAsync(suministra);

        public Task EliminarSuministroAsync(int id) => _dao.EliminarAsync(id);
    }
}
