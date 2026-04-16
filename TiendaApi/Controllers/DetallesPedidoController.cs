using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public DetallesPedidoController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/detallespedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TDetallesPedido>> GetById(int id)
        {
            var detallePedido = await _unidadTrabajo.TDetallesPedido.ObtenerPorIdAsync(id);
            if (detallePedido == null) return NotFound();
            return Ok(detallePedido);
        }

        // GET api/detallespedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDetallesPedido>>> GetAll()
        {
            var detallesPedido = await _unidadTrabajo.TDetallesPedido.ObtenerTodosAsync();
            return Ok(detallesPedido);
        }

        // POST api/detallespedido
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TDetallesPedido detallePedido)
        {
            await _unidadTrabajo.TDetallesPedido.AgregarAsync(detallePedido);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = detallePedido.DetalleId }, detallePedido);
        }

        // PUT api/detallespedido/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TDetallesPedido detallePedido)
        {
            if (id != detallePedido.DetalleId) return BadRequest();
            await _unidadTrabajo.TDetallesPedido.ActualizarAsync(detallePedido);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/detallespedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TDetallesPedido.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}