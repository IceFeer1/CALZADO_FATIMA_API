using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class EstadoPedidoService
    {
        private readonly EstadoPedidoDAO _dao;

        public EstadoPedidoService(EstadoPedidoDAO dao) => _dao = dao;

        public Task<List<EstadoPedido>> ObtenerEstadosAsync() => _dao.ObtenerTodosAsync();

        public Task<EstadoPedido?> ObtenerEstadoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearEstadoAsync(EstadoPedido estado)
        {
            if (string.IsNullOrWhiteSpace(estado.Descripcion))
                throw new ArgumentException("La descripcion es obligatoria.");

            await _dao.CrearAsync(estado);
        }

        public Task ActualizarEstadoAsync(EstadoPedido estado) => _dao.ActualizarAsync(estado);

        public Task EliminarEstadoAsync(int id) => _dao.EliminarAsync(id);
    }
}
