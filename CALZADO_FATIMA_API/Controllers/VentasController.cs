using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaService _service;

        public VentasController(VentaService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Venta>>> Get()
        {
            var ventas = await _service.ObtenerVentasAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> Get(int id)
        {
            var venta = await _service.ObtenerVentaAsync(id);
            return venta is null ? NotFound() : Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            await _service.CrearVentaAsync(venta);
            return CreatedAtAction(nameof(Get), new { id = venta.IdVenta }, venta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Venta venta)
        {
            if (id != venta.IdVenta) return BadRequest("El ID no coincide.");
            await _service.ActualizarVentaAsync(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarVentaAsync(id);
            return NoContent();
        }
    }
}
