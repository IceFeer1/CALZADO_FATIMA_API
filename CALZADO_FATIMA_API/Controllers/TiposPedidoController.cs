using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPedidoController : ControllerBase
    {
        private readonly TipoPedidoService _service;

        public TiposPedidoController(TipoPedidoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<TipoPedido>>> Get()
        {
            var tipos = await _service.ObtenerTiposAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPedido>> Get(int id)
        {
            var tipo = await _service.ObtenerTipoAsync(id);
            return tipo is null ? NotFound() : Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoPedido tipo)
        {
            await _service.CrearTipoAsync(tipo);
            return CreatedAtAction(nameof(Get), new { id = tipo.IdTipo }, tipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoPedido tipo)
        {
            if (id != tipo.IdTipo) return BadRequest("El ID no coincide.");
            await _service.ActualizarTipoAsync(tipo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarTipoAsync(id);
            return NoContent();
        }
    }
}
