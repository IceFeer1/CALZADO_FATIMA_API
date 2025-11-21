using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentasController : ControllerBase
    {
        private readonly DetalleVentaService _service;

        public DetalleVentasController(DetalleVentaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<DetalleVenta>>> Get()
        {
            var detalles = await _service.ObtenerDetallesAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> Get(int id)
        {
            var detalle = await _service.ObtenerDetalleAsync(id);
            return detalle is null ? NotFound() : Ok(detalle);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetalleVenta detalle)
        {
            await _service.CrearDetalleAsync(detalle);
            return CreatedAtAction(nameof(Get), new { id = detalle.IdDetalle }, detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DetalleVenta detalle)
        {
            if (id != detalle.IdDetalle) return BadRequest("El ID no coincide.");
            await _service.ActualizarDetalleAsync(detalle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarDetalleAsync(id);
            return NoContent();
        }
    }
}
