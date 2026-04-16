using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ProductoController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/producto/ABC123
        [HttpGet("{id}")]
        public async Task<ActionResult<TProducto>> GetById(string id)
        {
            var producto = await _unidadTrabajo.TProducto.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        // GET api/producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProducto>>> GetAll()
        {
            var productos = await _unidadTrabajo.TProducto.ObtenerTodosAsync();
            return Ok(productos);
        }

        // POST api/producto
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TProducto producto)
        {
            await _unidadTrabajo.TProducto.AgregarAsync(producto);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
        }

        // PUT api/producto/ABC123
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] TProducto producto)
        {
            if (id != producto.ProductoId) return BadRequest();
            await _unidadTrabajo.TProducto.ActualizarAsync(producto);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/producto/ABC123
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _unidadTrabajo.TProducto.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}