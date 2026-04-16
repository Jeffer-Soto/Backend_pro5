using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Dominio.Entidades;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;
using TiendaBatarazo.Utilitarios;
//using TiendaBatarazo.Dominio.InterfacesLN;

namespace TiendaBatarazo.LogicaNegocio
{
    public class CategoriaLN : ICategoriaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public CategoriaLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TCategoria?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TCategoria.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TCategoria>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TCategoria.ObtenerTodosAsync();
        }

        public async Task CrearCategoriaAsync(TCategoria categoria)
        {
            await _unidadTrabajo.TCategoria.AgregarAsync(categoria);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarCategoriaAsync(TCategoria categoria)
        {
            await _unidadTrabajo.TCategoria.ActualizarAsync(categoria);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarCategoriaAsync(int id)
        {
            await _unidadTrabajo.TCategoria.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}
