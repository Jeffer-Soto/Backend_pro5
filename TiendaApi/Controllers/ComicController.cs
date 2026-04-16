using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ComicController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/Comic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TComic>> GetById(int id)
        {
            var comic = await _unidadTrabajo.TComic.ObtenerPorIdAsync(id);
            if (comic == null) return NotFound();
            return Ok(comic);
        }

        // GET api/Comic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TComic>>> GetAll()
        {
            var comics = await _unidadTrabajo.TComic.ObtenerTodosAsync();
            return Ok(comics);
        }

        // POST api/Comic
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TComic comic)
        {
            await _unidadTrabajo.TComic.AgregarAsync(comic);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = comic.Id }, comic);
        }

        // PUT api/Comic/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TComic comic)
        {
            if (id != comic.Id) return BadRequest();
            await _unidadTrabajo.TComic.ActualizarAsync(comic);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/Comic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TComic.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}