using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPedido>> GetById(int id)
        {
            var pedido = await _unidadTrabajo.TPedido.ObtenerPorIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        // GET api/pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPedido>>> GetAll()
        {
            var pedidos = await _unidadTrabajo.TPedido.ObtenerTodosAsync();
            return Ok(pedidos);
        }

        // POST api/pedido
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TPedido pedido)
        {
            await _unidadTrabajo.TPedido.AgregarAsync(pedido);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = pedido.PedidoId }, pedido);
        }

        // PUT api/pedido/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TPedido pedido)
        {
            if (id != pedido.PedidoId) return BadRequest();
            await _unidadTrabajo.TPedido.ActualizarAsync(pedido);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TPedido.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}