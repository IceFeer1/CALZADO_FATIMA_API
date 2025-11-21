using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CALZADO_FATIMA_API.DAO
{
    public class RecibeDAO
    {
        private readonly CalzadoContext _context;

        public RecibeDAO(CalzadoContext context) => _context = context;

        public async Task<List<Recibe>> ObtenerTodosAsync() =>
            await _context.Recibe.AsNoTracking().ToListAsync();

        public async Task<Recibe?> ObtenerPorIdAsync(int id) =>
            await _context.Recibe.AsNoTracking().FirstOrDefaultAsync(r => r.IdProveedor == id);

        public async Task CrearAsync(Recibe recibe)
        {
            _context.Recibe.Add(recibe);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Recibe recibe)
        {
            _context.Recibe.Update(recibe);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var recibe = await _context.Recibe.FindAsync(id);
            if (recibe is null) return;
            _context.Recibe.Remove(recibe);
            await _context.SaveChangesAsync();
        }
    }
}
