using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Services
{
    public class RecibeService
    {
        private readonly RecibeDAO _dao;

        public RecibeService(RecibeDAO dao) => _dao = dao;

        public Task<List<Recibe>> ObtenerRecibosAsync() => _dao.ObtenerTodosAsync();

        public Task<Recibe?> ObtenerReciboAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearReciboAsync(Recibe recibe)
        {
            if (recibe.IdProveedor <= 0 || recibe.IdProducto <= 0)
                throw new ArgumentException("Proveedor y producto deben ser válidos.");

            await _dao.CrearAsync(recibe);
        }

        public Task ActualizarReciboAsync(Recibe recibe) => _dao.ActualizarAsync(recibe);

        public Task EliminarReciboAsync(int id) => _dao.EliminarAsync(id);
    }
}
