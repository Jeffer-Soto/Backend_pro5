using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.LogicaNegocio
{
    public class PedidoProveedorLN : IPedidoProveedorLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public PedidoProveedorLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TPedidoProveedor?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TPedidoProveedor.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TPedidoProveedor>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TPedidoProveedor.ObtenerTodosAsync();
        }

        public async Task CrearPedidoProveedorAsync(TPedidoProveedor pedido)
        {
            await _unidadTrabajo.TPedidoProveedor.AgregarAsync(pedido);
            _unidadTrabajo.Completar();
        }

        public async Task CambiarEstadoPedidoAsync(int id, string nuevoEstado)
        {
            var pedido = await _unidadTrabajo.TPedidoProveedor.ObtenerPorIdAsync(id);
            if (pedido != null)
            {
                pedido.Estado = nuevoEstado;
                await _unidadTrabajo.TPedidoProveedor.ActualizarAsync(pedido);
                _unidadTrabajo.Completar();
            }
        }
    }
}