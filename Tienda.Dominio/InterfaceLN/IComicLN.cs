using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.InterfaceLN
{
    public interface IComicLN
    {
        Task<TComic?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TComic>> ObtenerTodosAsync();
        Task CrearComicAsync(TComic comic);
        Task ActualizarComicAsync(TComic comic);
        Task EliminarComicAsync(int id);
    }

}