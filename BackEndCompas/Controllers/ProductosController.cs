using Microsoft.AspNetCore.Mvc;
using BackEndCompas.Data;
using BackEndCompas.Models;
using Microsoft.EntityFrameworkCore;
using BackEndCompas.Services.Interfaces;

namespace BackEndCompas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var nuevoProducto = await _productoService.AddProductoAsync(producto);
            return CreatedAtAction("GetProducto", new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            var resultado = await _productoService.UpdateProductoAsync(id, producto);
            if (!resultado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var resultado = await _productoService.DeleteProductoAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
