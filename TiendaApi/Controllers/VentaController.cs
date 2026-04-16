using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public VentaController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TVenta>> GetById(int id)
        {
            var venta = await _unidadTrabajo.TVenta.ObtenerPorIdAsync(id);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVenta>>> GetAll()
        {
            var ventas = await _unidadTrabajo.TVenta.ObtenerTodosAsync();
            return Ok(ventas);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TVenta venta)
        {
            await _unidadTrabajo.TVenta.AgregarAsync(venta);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TVenta venta)
        {
            if (id != venta.Id) return BadRequest();
            await _unidadTrabajo.TVenta.ActualizarAsync(venta);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TVenta.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}