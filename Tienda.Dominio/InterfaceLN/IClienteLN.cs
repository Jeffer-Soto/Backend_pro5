using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IClienteLN
    {
        Task<TCliente?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TCliente>> ObtenerTodosAsync();
        Task CrearClienteAsync(TCliente cliente);
        Task ActualizarClienteAsync(TCliente cliente);
        Task EliminarClienteAsync(int id);
    }
}
