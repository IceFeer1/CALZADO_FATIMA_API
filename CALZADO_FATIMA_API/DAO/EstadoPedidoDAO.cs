using CALZADO_FATIMA_API.Models;
using CALZADO_FATIMA_API.Data; 
using Microsoft.EntityFrameworkCore; 
namespace CALZADO_FATIMA_API.DAO
{
    public class EstadoPedidoDAO
    {
        private readonly CalzadoContext _context;

        public EstadoPedidoDAO(CalzadoContext context) => _context = context;

        public async Task<List<EstadoPedido>> ObtenerTodosAsync() =>
            await _context.EstadosPedido.AsNoTracking().ToListAsync();

        public async Task<EstadoPedido?> ObtenerPorIdAsync(int id) =>
            await _context.EstadosPedido.AsNoTracking().FirstOrDefaultAsync(e => e.IdEstado == id);

        public async Task CrearAsync(EstadoPedido estado)
        {
            _context.EstadosPedido.Add(estado);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(EstadoPedido estado)
        {
            _context.EstadosPedido.Update(estado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var estado = await _context.EstadosPedido.FindAsync(id);
            if (estado is null) return;
            _context.EstadosPedido.Remove(estado);
            await _context.SaveChangesAsync();
        }
    }
}
