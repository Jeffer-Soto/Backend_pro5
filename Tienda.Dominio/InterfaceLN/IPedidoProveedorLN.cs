using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IPedidoProveedorLN
    {
        Task<TPedidoProveedor?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TPedidoProveedor>> ObtenerTodosAsync();
        Task CrearPedidoProveedorAsync(TPedidoProveedor pedido);
        Task CambiarEstadoPedidoAsync(int id, string nuevoEstado);
    }
}