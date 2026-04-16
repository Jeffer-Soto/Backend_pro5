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
    public class DetalleVentaLN : IDetalleVentaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public DetalleVentaLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TDetalleVenta?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TDetalleVenta.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TDetalleVenta>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TDetalleVenta.ObtenerTodosAsync();
        }
    }
}
