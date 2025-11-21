using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;
namespace CALZADO_FATIMA_API.DAO
{
    public class ProductoDAO
    {
        private readonly CalzadoContext _context; 
        public ProductoDAO(CalzadoContext context) => _context = context;

        public async Task<List<Producto>> ObtenerTodosAsync() =>
            await _context.Productos.AsNoTracking().ToListAsync(); 
        public async Task<Producto?> ObtenerPorIdAsync(int id) => 
            await _context.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.IdProducto == id);
        public async Task CrearAsync(Producto producto)

        {
            _context.Productos.Add(producto); 
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto is null) return;
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}
