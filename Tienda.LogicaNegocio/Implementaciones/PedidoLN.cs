using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.LogicaNegocio
{
    public class PedidoLN : IPedidoLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TPedido?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TPedido.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TPedido>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TPedido.ObtenerTodosAsync();
        }

        public async Task CrearPedidoAsync(TPedido pedido, IEnumerable<object> detalles)
        {
            await _unidadTrabajo.TPedido.AgregarAsync(pedido);
            _unidadTrabajo.Completar();
        }
    }
}