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
namespace TiendaBatarazo.LogicaNegocio
{
    public class ProductoLN : IProductoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ProductoLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TProducto?> ObtenerPorIdAsync(string id)
        {
            return await _unidadTrabajo.TProducto.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TProducto>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TProducto.ObtenerTodosAsync();
        }

        public async Task CrearProductoAsync(TProducto producto)
        {
            await _unidadTrabajo.TProducto.AgregarAsync(producto);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarProductoAsync(TProducto producto)
        {
            await _unidadTrabajo.TProducto.ActualizarAsync(producto);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarProductoAsync(string id)
        {
            await _unidadTrabajo.TProducto.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}