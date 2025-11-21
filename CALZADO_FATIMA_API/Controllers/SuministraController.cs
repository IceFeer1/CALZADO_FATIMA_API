using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuministraController : ControllerBase
    {
        private readonly SuministraService _service;

        public SuministraController(SuministraService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Suministra>>> Get()
        {
            var suministros = await _service.ObtenerSuministrosAsync();
            return Ok(suministros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Suministra>> Get(int id)
        {
            var suministro = await _service.ObtenerSuministroAsync(id);
            return suministro is null ? NotFound() : Ok(suministro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Suministra suministra)
        {
            await _service.CrearSuministroAsync(suministra);
            return CreatedAtAction(nameof(Get), new { id = suministra.IdProveedor }, suministra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Suministra suministra)
        {
            if (id != suministra.IdProveedor) return BadRequest("El ID no coincide.");
            await _service.ActualizarSuministroAsync(suministra);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarSuministroAsync(id);
            return NoContent();
        }
    }
}
