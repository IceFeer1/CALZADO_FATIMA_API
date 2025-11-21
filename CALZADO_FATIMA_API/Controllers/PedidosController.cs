using CALZADO_FATIMA_API.Models;
using CALZADO_FATIMA_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidosController(PedidoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            var pedidos = await _service.ObtenerPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var pedido = await _service.ObtenerPedidoAsync(id);
            return pedido is null ? NotFound() : Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            await _service.CrearPedidoAsync(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.IdPedido) return BadRequest("El ID no coincide.");
            await _service.ActualizarPedidoAsync(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarPedidoAsync(id);
            return NoContent();
        }
    }
}
