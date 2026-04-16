using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IProveedorLN
    {
        Task<TProveedor?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TProveedor>> ObtenerTodosAsync();
        Task CrearProveedorAsync(TProveedor proveedor);
        Task ActualizarProveedorAsync(TProveedor proveedor);
        Task EliminarProveedorAsync(int id);
    }
}