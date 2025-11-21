using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models; 

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosPedidoController : ControllerBase
    {
        private readonly EstadoPedidoService _service;

        public EstadosPedidoController(EstadoPedidoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<EstadoPedido>>> Get()
        {
            var estados = await _service.ObtenerEstadosAsync();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPedido>> Get(int id)
        {
            var estado = await _service.ObtenerEstadoAsync(id);
            return estado is null ? NotFound() : Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstadoPedido estado)
        {
            await _service.CrearEstadoAsync(estado);
            return CreatedAtAction(nameof(Get), new { id = estado.IdEstado }, estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadoPedido estado)
        {
            if (id != estado.IdEstado) return BadRequest("El ID no coincide.");
            await _service.ActualizarEstadoAsync(estado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarEstadoAsync(id);
            return NoContent();
        }
    }
}
