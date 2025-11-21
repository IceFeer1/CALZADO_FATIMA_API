using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Services
{
    public class TipoPedidoService
    {
        private readonly TipoPedidoDAO _dao;

        public TipoPedidoService(TipoPedidoDAO dao) => _dao = dao;

        public Task<List<TipoPedido>> ObtenerTiposAsync() => _dao.ObtenerTodosAsync();

        public Task<TipoPedido?> ObtenerTipoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearTipoAsync(TipoPedido tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                throw new ArgumentException("El nombre del tipo de pedido es obligatorio.");

            await _dao.CrearAsync(tipo);
        }

        public Task ActualizarTipoAsync(TipoPedido tipo) => _dao.ActualizarAsync(tipo);

        public Task EliminarTipoAsync(int id) => _dao.EliminarAsync(id);
    }
}
