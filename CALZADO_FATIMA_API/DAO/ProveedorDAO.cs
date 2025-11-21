using CALZADO_FATIMA_API.Models;
using CALZADO_FATIMA_API.Data;
using Microsoft.EntityFrameworkCore; 
namespace CALZADO_FATIMA_API.DAO
{
    public class ProveedorDAO
    {
        private readonly CalzadoContext _context;

        public ProveedorDAO(CalzadoContext context) => _context = context;

        public async Task<List<Proveedor>> ObtenerTodosAsync() =>
            await _context.Proveedores.AsNoTracking().ToListAsync();

        public async Task<Proveedor?> ObtenerPorIdAsync(int id) =>
            await _context.Proveedores.AsNoTracking().FirstOrDefaultAsync(p => p.IdProveedor == id);

        public async Task CrearAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor is null) return;
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}
