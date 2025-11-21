using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecibeController : ControllerBase
    {
        private readonly RecibeService _service;

        public RecibeController(RecibeService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Recibe>>> Get()
        {
            var recibos = await _service.ObtenerRecibosAsync();
            return Ok(recibos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recibe>> Get(int id)
        {
            var recibe = await _service.ObtenerReciboAsync(id);
            return recibe is null ? NotFound() : Ok(recibe);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Recibe recibe)
        {
            await _service.CrearReciboAsync(recibe);
            return CreatedAtAction(nameof(Get), new { id = recibe.IdProveedor }, recibe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Recibe recibe)
        {
            if (id != recibe.IdProveedor) return BadRequest("El ID no coincide.");
            await _service.ActualizarReciboAsync(recibe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarReciboAsync(id);
            return NoContent();
        }
    }
}
