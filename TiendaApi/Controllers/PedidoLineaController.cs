using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoLineaController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoLineaController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/pedidolinea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPedidoLinea>> GetById(int id)
        {
            var pedidoLinea = await _unidadTrabajo.TPedidoLinea.ObtenerPorIdAsync(id);
            if (pedidoLinea == null) return NotFound();
            return Ok(pedidoLinea);
        }

        // GET api/pedidolinea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPedidoLinea>>> GetAll()
        {
            var pedidosLinea = await _unidadTrabajo.TPedidoLinea.ObtenerTodosAsync();
            return Ok(pedidosLinea);
        }

        // POST api/pedidolinea
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TPedidoLinea pedidoLinea)
        {
            await _unidadTrabajo.TPedidoLinea.AgregarAsync(pedidoLinea);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = pedidoLinea.Id }, pedidoLinea);
        }

        // PUT api/pedidolinea/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TPedidoLinea pedidoLinea)
        {
            if (id != pedidoLinea.Id) return BadRequest();
            await _unidadTrabajo.TPedidoLinea.ActualizarAsync(pedidoLinea);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/pedidolinea/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TPedidoLinea.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}