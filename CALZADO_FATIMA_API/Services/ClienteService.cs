using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteDAO _dao;

        public ClienteService(ClienteDAO dao) => _dao = dao;

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync() =>
            await _dao.ObtenerTodosAsync();

        public async Task<Cliente?> ObtenerPorIdAsync(int id) =>
            await _dao.ObtenerPorIdAsync(id);

        public async Task<Cliente> CrearAsync(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            await _dao.CrearAsync(cliente);
            return cliente;
        }

        public async Task<Cliente?> ActualizarAsync(int id, Cliente cliente)
        {
            var actualizado = await _dao.ActualizarAsync(id, cliente);
            return actualizado;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var existente = await _dao.ObtenerPorIdAsync(id);
            if (existente is null) return false;

            await _dao.EliminarAsync(id);
            return true;
        }

    }
}
