using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IProductoLN
    {
        Task<TProducto?> ObtenerPorIdAsync(string id);
        Task<IEnumerable<TProducto>> ObtenerTodosAsync();
        Task CrearProductoAsync(TProducto producto);
        Task ActualizarProductoAsync(TProducto producto);
        Task EliminarProductoAsync(string id);
    }


}
