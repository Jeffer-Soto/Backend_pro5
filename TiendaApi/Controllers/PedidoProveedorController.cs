using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoProveedorController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoProveedorController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/pedidoproveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPedidoProveedor>> GetById(int id)
        {
            var pedidoProveedor = await _unidadTrabajo.TPedidoProveedor.ObtenerPorIdAsync(id);
            if (pedidoProveedor == null) return NotFound();
            return Ok(pedidoProveedor);
        }

        // GET api/pedidoproveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPedidoProveedor>>> GetAll()
        {
            var pedidosProveedor = await _unidadTrabajo.TPedidoProveedor.ObtenerTodosAsync();
            return Ok(pedidosProveedor);
        }

        // POST api/pedidoproveedor
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TPedidoProveedor pedidoProveedor)
        {
            await _unidadTrabajo.TPedidoProveedor.AgregarAsync(pedidoProveedor);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = pedidoProveedor.Id }, pedidoProveedor);
        }

        // PUT api/pedidoproveedor/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TPedidoProveedor pedidoProveedor)
        {
            if (id != pedidoProveedor.Id) return BadRequest();
            await _unidadTrabajo.TPedidoProveedor.ActualizarAsync(pedidoProveedor);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/pedidoproveedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TPedidoProveedor.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}