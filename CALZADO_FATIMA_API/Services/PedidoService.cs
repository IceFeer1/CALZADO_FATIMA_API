using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class PedidoService
    {
        private readonly PedidoDAO _dao;

        public PedidoService(PedidoDAO dao) => _dao = dao;

        public Task<List<Pedido>> ObtenerPedidosAsync() => _dao.ObtenerTodosAsync();

        public Task<Pedido?> ObtenerPedidoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearPedidoAsync(Pedido pedido)
        {
            if (pedido.IdCliente <= 0)
                throw new ArgumentException("El pedido debe estar asociado a un cliente válido.");

            await _dao.CrearAsync(pedido);
        }

        public Task ActualizarPedidoAsync(Pedido pedido) => _dao.ActualizarAsync(pedido);

        public Task EliminarPedidoAsync(int id) => _dao.EliminarAsync(id);
    }
}
