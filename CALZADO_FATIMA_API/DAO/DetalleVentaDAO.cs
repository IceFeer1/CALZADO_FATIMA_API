using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore; 
namespace CALZADO_FATIMA_API.DAO
{
    public class DetalleVentaDAO
    {
        private readonly CalzadoContext _context;

        public DetalleVentaDAO(CalzadoContext context) => _context = context;

        public async Task<List<DetalleVenta>> ObtenerTodosAsync() =>
            await _context.DetalleVentas.AsNoTracking().ToListAsync();

        public async Task<DetalleVenta?> ObtenerPorIdAsync(int id) =>
            await _context.DetalleVentas.AsNoTracking().FirstOrDefaultAsync(d => d.IdDetalle == id);

        public async Task CrearAsync(DetalleVenta detalle)
        {
            _context.DetalleVentas.Add(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(DetalleVenta detalle)
        {
            _context.DetalleVentas.Update(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var detalle = await _context.DetalleVentas.FindAsync(id);
            if (detalle is null) return;
            _context.DetalleVentas.Remove(detalle);
            await _context.SaveChangesAsync();
        }
    }
}
