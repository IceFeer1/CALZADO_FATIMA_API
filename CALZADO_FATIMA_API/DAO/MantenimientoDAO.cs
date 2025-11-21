using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore; 
namespace CALZADO_FATIMA_API.DAO
{
    public class MantenimientoDAO
    {
        private readonly CalzadoContext _context;

        public MantenimientoDAO(CalzadoContext context) => _context = context;

        public async Task<List<Mantenimiento>> ObtenerTodosAsync() =>
            await _context.Mantenimientos.AsNoTracking().ToListAsync();

        public async Task<Mantenimiento?> ObtenerPorIdAsync(int id) =>
            await _context.Mantenimientos.AsNoTracking().FirstOrDefaultAsync(m => m.IdMantenimiento == id);

        public async Task CrearAsync(Mantenimiento mantenimiento)
        {
            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Mantenimiento mantenimiento)
        {
            _context.Mantenimientos.Update(mantenimiento);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento is null) return;
            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();
        }
    }
}
