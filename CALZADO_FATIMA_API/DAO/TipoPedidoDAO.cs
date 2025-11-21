using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CALZADO_FATIMA_API.DAO
{
    public class TipoPedidoDAO
    {
        private readonly CalzadoContext _context;

        public TipoPedidoDAO(CalzadoContext context) => _context = context;

        public async Task<List<TipoPedido>> ObtenerTodosAsync() =>
            await _context.TiposPedido.AsNoTracking().ToListAsync();

        public async Task<TipoPedido?> ObtenerPorIdAsync(int id) =>
            await _context.TiposPedido.AsNoTracking().FirstOrDefaultAsync(t => t.IdTipo == id);

        public async Task CrearAsync(TipoPedido tipo)
        {
            _context.TiposPedido.Add(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(TipoPedido tipo)
        {
            _context.TiposPedido.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var tipo = await _context.TiposPedido.FindAsync(id);
            if (tipo is null) return;
            _context.TiposPedido.Remove(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
