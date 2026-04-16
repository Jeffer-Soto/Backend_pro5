using AutoMapper;
using TiendaBatarazo.Dominio.Entidades;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Utilitarios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace TiendaBatarazo.LogicaNegocio
{
    public class ComicLN : IComicLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ComicLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TComic?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TComic.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TComic>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TComic.ObtenerTodosAsync();
        }

        public async Task CrearComicAsync(TComic comic)
        {
            await _unidadTrabajo.TComic.AgregarAsync(comic);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarComicAsync(TComic comic)
        {
            await _unidadTrabajo.TComic.ActualizarAsync(comic);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarComicAsync(int id)
        {
            await _unidadTrabajo.TComic.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}