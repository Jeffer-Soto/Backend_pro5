using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IDetallesPedidoLN
    {
        Task<TDetallesPedido?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TDetallesPedido>> ObtenerTodosAsync();
    }
}