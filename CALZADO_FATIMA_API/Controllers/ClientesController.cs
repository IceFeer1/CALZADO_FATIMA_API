using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await _service.ObtenerTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _service.ObtenerPorIdAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            var creado = await _service.CrearAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = creado.IdCliente }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.IdCliente) return BadRequest("El ID no coincide.");

            var actualizado = await _service.ActualizarAsync(id, cliente);
            return actualizado is null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.EliminarAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
