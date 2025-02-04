using Microsoft.AspNetCore.Mvc;
using BackEndCompas.Data;
using BackEndCompas.Models;
using Microsoft.EntityFrameworkCore;
using BackEndCompas.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "writter,reader")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        [Authorize(Roles = "writter,reader")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [Authorize(Roles = "writter")]
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre))
                return BadRequest("Debe indicar un nombre");

            if (string.IsNullOrEmpty(producto.Descripcion))
                return BadRequest("Debe indicar una descripción");

            if (producto.Precio < 0)
                return BadRequest("El precio debe ser mayor o igual a 0");

            if (producto.Stock < 0)
                return BadRequest("El Stock debe ser mayor o igual a 0");

            var nuevoProducto = await _productoService.AddProductoAsync(producto);
            return CreatedAtAction("GetProducto", new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [Authorize(Roles = "writter")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre))
                return BadRequest("Debe indicar un nombre");

            if (string.IsNullOrEmpty(producto.Descripcion))
                return BadRequest("Debe indicar una descripción");

            if(producto.Precio < 0)
                return BadRequest("El precio debe ser mayor o igual a 0");

            if(producto.Stock < 0)
                return BadRequest("El Stock debe ser mayor o igual a 0");

            var resultado = await _productoService.UpdateProductoAsync(id, producto);
            if (!resultado) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "writter")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var resultado = await _productoService.DeleteProductoAsync(id);
            if (!resultado) return NotFound();
            return NoContent();
        }

        //para probar el servicio sin autenticación
        [HttpGet("prueba")]
        public async Task<IActionResult> Prueba()
        {
            return Ok();
        }
    }
}
