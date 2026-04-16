using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IUsuarioLN
    {
        Task<TUsuario?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TUsuario>> ObtenerTodosAsync();
        Task CrearUsuarioAsync(TUsuario usuario);
        Task ActualizarUsuarioAsync(TUsuario usuario);
        Task EliminarUsuarioAsync(int id);
    }
}
