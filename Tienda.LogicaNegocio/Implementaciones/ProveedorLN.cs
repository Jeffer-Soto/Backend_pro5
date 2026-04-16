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
    public class ProveedorLN : IProveedorLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ProveedorLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TProveedor?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TProveedor.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TProveedor>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TProveedor.ObtenerTodosAsync();
        }

        public async Task CrearProveedorAsync(TProveedor proveedor)
        {
            await _unidadTrabajo.TProveedor.AgregarAsync(proveedor);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarProveedorAsync(TProveedor proveedor)
        {
            await _unidadTrabajo.TProveedor.ActualizarAsync(proveedor);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarProveedorAsync(int id)
        {
            await _unidadTrabajo.TProveedor.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}

