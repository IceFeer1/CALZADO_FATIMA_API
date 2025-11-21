using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class ProveedorService
    {
        private readonly ProveedorDAO _dao;

        public ProveedorService(ProveedorDAO dao) => _dao = dao;

        public Task<List<Proveedor>> ObtenerProveedoresAsync() => _dao.ObtenerTodosAsync();

        public Task<Proveedor?> ObtenerProveedorAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearProveedorAsync(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.NombreProveedor))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");

            await _dao.CrearAsync(proveedor);
        }

        public Task ActualizarProveedorAsync(Proveedor proveedor) => _dao.ActualizarAsync(proveedor);

        public Task EliminarProveedorAsync(int id) => _dao.EliminarAsync(id);
    }
}
