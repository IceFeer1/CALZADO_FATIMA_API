using CALZADO_FATIMA_API.Data;
using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore; 
namespace CALZADO_FATIMA_API.DAO
{
    public class ClienteDAO
    {
        private readonly CalzadoContext _context;

        public ClienteDAO(CalzadoContext context) => _context = context;

        public async Task<List<Cliente>> ObtenerTodosAsync() =>
            await _context.Clientes.AsNoTracking().ToListAsync();

        public async Task<Cliente?> ObtenerPorIdAsync(int id) =>
            await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.IdCliente == id); 

        public async Task CrearAsync (Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync(); 
        }
        public async Task<Cliente?> ActualizarAsync(int id, Cliente cliente)
        {
            var existente = await _context.Clientes.FindAsync(id);
            if (existente is null) return null;

            existente.NombreCliente = cliente.NombreCliente;
            existente.ApellidoCliente = cliente.ApellidoCliente;
            existente.DireccionCliente = cliente.DireccionCliente;
            existente.TelefonoCliente = cliente.TelefonoCliente;

            await _context.SaveChangesAsync();
            return existente;
        }


        public async Task EliminarAsync (int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null) return; 
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
