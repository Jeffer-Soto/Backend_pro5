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
    public class UsuarioLN : IUsuarioLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public UsuarioLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TUsuario?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TUsuario.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TUsuario>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TUsuario.ObtenerTodosAsync();
        }

        public async Task CrearUsuarioAsync(TUsuario usuario)
        {
            await _unidadTrabajo.TUsuario.AgregarAsync(usuario);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarUsuarioAsync(TUsuario usuario)
        {
            await _unidadTrabajo.TUsuario.ActualizarAsync(usuario);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            await _unidadTrabajo.TUsuario.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}
