using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public UsuarioController(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TUsuario>> GetById(int id)
        {
            var usuario = await _unidadTrabajo.TUsuario.ObtenerPorIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        // GET api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TUsuario>>> GetAll()
        {
            var usuarios = await _unidadTrabajo.TUsuario.ObtenerTodosAsync();
            return Ok(usuarios);
        }

        // POST api/usuario
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TUsuario usuario)
        {
            await _unidadTrabajo.TUsuario.AgregarAsync(usuario);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TUsuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            await _unidadTrabajo.TUsuario.ActualizarAsync(usuario);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TUsuario.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}
