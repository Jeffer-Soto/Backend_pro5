using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IDetalleVentaLN
    {
        Task<TDetalleVenta?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TDetalleVenta>> ObtenerTodosAsync();
    }
}
