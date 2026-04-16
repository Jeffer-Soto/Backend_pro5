using Microsoft.AspNetCore.Mvc;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorControl : ControllerBase
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ProveedorControl(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        // GET api/proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TProveedor>> GetById(int id)
        {
            var proveedor = await _unidadTrabajo.TProveedor.ObtenerPorIdAsync(id);
            if (proveedor == null) return NotFound();
            return Ok(proveedor);
        }

        // GET api/proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProveedor>>> GetAll()
        {
            var proveedores = await _unidadTrabajo.TProveedor.ObtenerTodosAsync();
            return Ok(proveedores);
        }

        // POST api/proveedor
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TProveedor proveedor)
        {
            await _unidadTrabajo.TProveedor.AgregarAsync(proveedor);
            _unidadTrabajo.Completar();
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
        }

        // PUT api/proveedor/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TProveedor proveedor)
        {
            if (id != proveedor.Id) return BadRequest();
            await _unidadTrabajo.TProveedor.ActualizarAsync(proveedor);
            _unidadTrabajo.Completar();
            return NoContent();
        }

        // DELETE api/proveedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _unidadTrabajo.TProveedor.EliminarAsync(id);
            _unidadTrabajo.Completar();
            return NoContent();
        }
    }
}