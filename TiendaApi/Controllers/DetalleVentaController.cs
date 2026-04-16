using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public DetalleVentaController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/detalleventa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TDetalleVenta>> GetById(int id)
        {
            var detalleVenta = await _unidadTrabajo.TDetalleVenta.ObtenerPorIdAsync(id);
            if (detalleVenta == null) return NotFound();
            return Ok(detalleVenta);
        }

        // GET api/detalleventa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDetalleVenta>>> GetAll()
        {
            var detallesVenta = await _unidadTrabajo.TDetalleVenta.ObtenerTodosAsync();
            return Ok(detallesVenta);
        }

        // POST api/detalleventa
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TDetalleVenta detalleVenta)
        {
            await _unidadTrabajo.TDetalleVenta.AgregarAsync(detalleVenta);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = detalleVenta.Id }, detalleVenta);
        }

        // PUT api/detalleventa/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TDetalleVenta detalleVenta)
        {
            if (id != detalleVenta.Id) return BadRequest();
            await _unidadTrabajo.TDetalleVenta.ActualizarAsync(detalleVenta);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/detalleventa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TDetalleVenta.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}