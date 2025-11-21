using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models; 

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly MantenimientoService _service;

        public MantenimientosController(MantenimientoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Mantenimiento>>> Get()
        {
            var mantenimientos = await _service.ObtenerMantenimientosAsync();
            return Ok(mantenimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> Get(int id)
        {
            var mantenimiento = await _service.ObtenerMantenimientoAsync(id);
            return mantenimiento is null ? NotFound() : Ok(mantenimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mantenimiento mantenimiento)
        {
            await _service.CrearMantenimientoAsync(mantenimiento);
            return CreatedAtAction(nameof(Get), new { id = mantenimiento.IdMantenimiento }, mantenimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.IdMantenimiento) return BadRequest("El ID no coincide.");
            await _service.ActualizarMantenimientoAsync(mantenimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarMantenimientoAsync(id);
            return NoContent();
        }
    }
}
