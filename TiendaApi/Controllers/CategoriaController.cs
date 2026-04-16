using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public CategoriaController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TCategoria>> GetById(int id)
        {
            var categoria = await _unidadTrabajo.TCategoria.ObtenerPorIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        // GET api/categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TCategoria>>> GetAll()
        {
            var categorias = await _unidadTrabajo.TCategoria.ObtenerTodosAsync();
            return Ok(categorias);
        }

        // POST api/categoria
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TCategoria categoria)
        {
            await _unidadTrabajo.TCategoria.AgregarAsync(categoria);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = categoria.CategoriaId }, categoria);
        }

        // PUT api/categoria/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TCategoria categoria)
        {
            if (id != categoria.CategoriaId) return BadRequest();
            await _unidadTrabajo.TCategoria.ActualizarAsync(categoria);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/categoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TCategoria.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}