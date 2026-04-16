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
    public class PedidoLineaLN : IPedidoLineaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoLineaLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TPedidoLinea?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TPedidoLinea.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TPedidoLinea>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TPedidoLinea.ObtenerTodosAsync();
        }
    }
}
