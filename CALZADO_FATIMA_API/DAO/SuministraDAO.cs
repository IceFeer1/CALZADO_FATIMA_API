using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CALZADO_FATIMA_API.DAO
{
    public class SuministraDAO
    {
        private readonly CalzadoContext _context;

        public SuministraDAO(CalzadoContext context) => _context = context;

        public async Task<List<Suministra>> ObtenerTodosAsync() =>
            await _context.Suministra.AsNoTracking().ToListAsync();

        public async Task<Suministra?> ObtenerPorIdAsync(int id) =>
            await _context.Suministra.AsNoTracking().FirstOrDefaultAsync(s => s.IdProveedor == id);

        public async Task CrearAsync(Suministra suministra)
        {
            _context.Suministra.Add(suministra);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Suministra suministra)
        {
            _context.Suministra.Update(suministra);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var suministra = await _context.Suministra.FindAsync(id);
            if (suministra is null) return;
            _context.Suministra.Remove(suministra);
            await _context.SaveChangesAsync();
        }
    }
}
