using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IPedidoLN
    {
        Task<TPedido?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TPedido>> ObtenerTodosAsync();
    }

}
