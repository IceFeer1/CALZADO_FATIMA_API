using CALZADO_FATIMA_API.DAO;
using CALZADO_FATIMA_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CALZADO_FATIMA_API.Services
{
    public class MantenimientoService
    {
        private readonly MantenimientoDAO _dao;

        public MantenimientoService(MantenimientoDAO dao) => _dao = dao;

        /// Obtiene una lista de todos los mantenimientos.
        public Task<List<Mantenimiento>> ObtenerMantenimientosAsync() => _dao.ObtenerTodosAsync();

        /// Obtiene un mantenimiento por su Id.
        public Task<Mantenimiento?> ObtenerMantenimientoAsync(int id) => _dao.ObtenerPorIdAsync(id);

        /// Crea un nuevo registro de mantenimiento.
        public async Task CrearMantenimientoAsync(Mantenimiento mantenimiento)
        {
            // Nota: Se ha eliminado la validación de 'Descripcion' ya que no existe en el modelo.
            // Aquí puedes agregar validaciones basadas en las nuevas propiedades del modelo:
            // Por ejemplo, verificar que los IDs sean válidos y la fecha sea razonable.

            if (mantenimiento.IdProducto <= 0)
                throw new ArgumentException("El IdProducto es obligatorio y debe ser positivo.");

            if (mantenimiento.IdProveedor <= 0)
                throw new ArgumentException("El IdProveedor es obligatorio y debe ser positivo.");

            if (mantenimiento.FechaMantenimiento == default)
                throw new ArgumentException("La FechaMantenimiento es obligatoria.");

            await _dao.CrearAsync(mantenimiento);
        }

        /// Actualiza un registro de mantenimiento existente.
        public Task ActualizarMantenimientoAsync(Mantenimiento mantenimiento) => _dao.ActualizarAsync(mantenimiento);

        /// Elimina un registro de mantenimiento por su Id.
        public Task EliminarMantenimientoAsync(int id) => _dao.EliminarAsync(id);
    }
}