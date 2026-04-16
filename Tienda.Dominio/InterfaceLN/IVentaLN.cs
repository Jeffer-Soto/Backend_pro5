using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IVentaLN
    {
        Task<TVenta?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TVenta>> ObtenerTodosAsync();
        Task RegistrarVentaAsync(TVenta venta, IEnumerable<TDetalleVenta> detalles);
    }
}
