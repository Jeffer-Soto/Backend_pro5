using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.Dominio.Entidades;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;
using TiendaBatarazo.Utilitarios;
namespace TiendaBatarazo.LogicaNegocio
{
    public class ClienteLN : IClienteLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public ClienteLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TCliente?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TCliente.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TCliente>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TCliente.ObtenerTodosAsync();
        }

        public async Task CrearClienteAsync(TCliente cliente)
        {
            await _unidadTrabajo.TCliente.AgregarAsync(cliente);
            _unidadTrabajo.Completar();
        }

        public async Task ActualizarClienteAsync(TCliente cliente)
        {
            await _unidadTrabajo.TCliente.ActualizarAsync(cliente);
            _unidadTrabajo.Completar();
        }

        public async Task EliminarClienteAsync(int id)
        {
            await _unidadTrabajo.TCliente.EliminarAsync(id);
            _unidadTrabajo.Completar();
        }
    }
}
