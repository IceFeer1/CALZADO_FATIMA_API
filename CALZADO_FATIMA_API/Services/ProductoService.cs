using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Services
{
    public class ProductoService
    {
        private readonly ProductoDAO _dao;

        public ProductoService(ProductoDAO dao) => _dao = dao;

        public Task<List<Producto>> ObtenerProductosAsync() => _dao.ObtenerTodosAsync();

        public Task<Producto?> ObtenerProductoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearProductoAsync(Producto producto)
        {
            if (producto.PrecioProducto < 0)
                throw new ArgumentException("El precio del producto no puede ser negativo.");

            await _dao.CrearAsync(producto);
        }

        public Task ActualizarProductoAsync(Producto producto) => _dao.ActualizarAsync(producto);

        public Task EliminarProductoAsync(int id) => _dao.EliminarAsync(id);
    }
}
