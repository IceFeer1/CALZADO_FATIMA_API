using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CALZADO_FATIMA_API.Services;
using CALZADO_FATIMA_API.Models; 

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ProveedorService _service;

        public ProveedoresController(ProveedorService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            var proveedores = await _service.ObtenerProveedoresAsync();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            var proveedor = await _service.ObtenerProveedorAsync(id);
            return proveedor is null ? NotFound() : Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Proveedor proveedor)
        {
            await _service.CrearProveedorAsync(proveedor);
            return CreatedAtAction(nameof(Get), new { id = proveedor.IdProveedor }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor) return BadRequest("El ID no coincide.");
            await _service.ActualizarProveedorAsync(proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarProveedorAsync(id);
            return NoContent();
        }
    }
}
