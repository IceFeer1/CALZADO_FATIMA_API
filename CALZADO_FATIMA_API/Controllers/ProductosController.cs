using CALZADO_FATIMA_API.Models;
using CALZADO_FATIMA_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CALZADO_FATIMA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            var productos = await _service.ObtenerProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _service.ObtenerProductoAsync(id);
            return producto is null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _service.CrearProductoAsync(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.IdProducto }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest("El ID no coincide.");
            await _service.ActualizarProductoAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarProductoAsync(id);
            return NoContent();
        }
    }
}
