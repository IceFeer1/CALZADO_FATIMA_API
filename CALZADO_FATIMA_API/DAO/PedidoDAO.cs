using CALZADO_FATIMA_API.Data; 
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;
namespace CALZADO_FATIMA_API.DAO
{
    public class PedidoDAO
    {
        private readonly CalzadoContext _context;

        public PedidoDAO(CalzadoContext context) => _context = context;

        public async Task<List<Pedido>> ObtenerTodosAsync() =>
            await _context.Pedidos.AsNoTracking().ToListAsync();

        public async Task<Pedido?> ObtenerPorIdAsync(int id) =>
            await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.IdPedido == id);

        public async Task CrearAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido is null) return;
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
