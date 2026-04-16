using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.LogicaNegocio
{
    public class DetallesPedidoLN : IDetallesPedidoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public DetallesPedidoLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TDetallesPedido?> ObtenerPorIdAsync(int id)
        {
            return await Task.FromResult<TDetallesPedido?>(null);
        }

        public async Task<IEnumerable<TDetallesPedido>> ObtenerTodosAsync()
        {
            return await Task.FromResult<IEnumerable<TDetallesPedido>>(new List<TDetallesPedido>());
        }
    }
}