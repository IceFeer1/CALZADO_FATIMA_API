using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Services
{
    public class MantenimientoService
    {
        private readonly MantenimientoDAO _dao;

        public MantenimientoService(MantenimientoDAO dao) => _dao = dao;

        public Task<List<Mantenimiento>> ObtenerMantenimientosAsync() => _dao.ObtenerTodosAsync();

        public Task<Mantenimiento?> ObtenerMantenimientoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        public async Task CrearMantenimientoAsync(Mantenimiento mantenimiento)
        {
            if (string.IsNullOrWhiteSpace(mantenimiento.Descripcion))
                throw new ArgumentException("La descripción del mantenimiento es obligatoria.");

            await _dao.CrearAsync(mantenimiento);
        }

        public Task ActualizarMantenimientoAsync(Mantenimiento mantenimiento) => _dao.ActualizarAsync(mantenimiento);

        public Task EliminarMantenimientoAsync(int id) => _dao.EliminarAsync(id);
    }
}
