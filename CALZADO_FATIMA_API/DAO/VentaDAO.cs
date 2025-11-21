using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CALZADO_FATIMA_API.DAO
{
    public class VentaDAO
    {
        private readonly CalzadoContext _context;

        public VentaDAO(CalzadoContext context) => _context = context;

        public async Task<List<Venta>> ObtenerTodasAsync() =>
            await _context.Ventas.AsNoTracking().ToListAsync();

        public async Task<Venta?> ObtenerPorIdAsync(int id) =>
            await _context.Ventas.AsNoTracking().FirstOrDefaultAsync(v => v.IdVenta == id);

        public async Task CrearAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Venta venta)
        {
            _context.Ventas.Update(venta);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta is null) return;
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
        }
    }
}
