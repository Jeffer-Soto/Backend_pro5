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
    public class VentaLN : IVentaLN
    {
        private readonly IUnidadTrabajoEF _unidadTrabajo;

        public VentaLN(IUnidadTrabajoEF unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<TVenta?> ObtenerPorIdAsync(int id)
        {
            return await _unidadTrabajo.TVenta.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<TVenta>> ObtenerTodosAsync()
        {
            return await _unidadTrabajo.TVenta.ObtenerTodosAsync();
        }

        public async Task RegistrarVentaAsync(TVenta venta, IEnumerable<TDetalleVenta> detalles)
        {
            // 1. Registrar la venta
            await _unidadTrabajo.TVenta.AgregarAsync(venta);
            _unidadTrabajo.Completar();

            // 2. Registrar los detalles de la venta
            foreach (var detalle in detalles)
            {
                detalle.IdVenta = venta.Id; // asignar la FK
                await _unidadTrabajo.TDetalleVenta.AgregarAsync(detalle);

                // 3. Actualizar stock del cómic
                var comic = await _unidadTrabajo.TComic.ObtenerPorIdAsync(detalle.IdComic);
                if (comic != null)
                {
                    comic.Stock -= detalle.Cantidad;
                    await _unidadTrabajo.TComic.ActualizarAsync(comic);
                }
            }

            // 4. Guardar todos los cambios
            _unidadTrabajo.Completar();
        }
    }
}
