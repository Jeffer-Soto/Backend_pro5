using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface ICategoriaLN
    {
        Task<TCategoria?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TCategoria>> ObtenerTodosAsync();
        Task CrearCategoriaAsync(TCategoria categoria);
        Task ActualizarCategoriaAsync(TCategoria categoria);
        Task EliminarCategoriaAsync(int id);
    }


}
