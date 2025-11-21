using CALZADO_FATIMA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CALZADO_FATIMA_API.Services
{
 
    public interface IClienteService
    {
       Task<IEnumerable<Cliente>> ObtenerTodosAsync();
       Task<Cliente?> ObtenerPorIdAsync(int id);
       Task<Cliente> CrearAsync(Cliente cliente);
       Task<Cliente?> ActualizarAsync(int id, Cliente cliente);
       Task<bool> EliminarAsync(int id);
    }
}
