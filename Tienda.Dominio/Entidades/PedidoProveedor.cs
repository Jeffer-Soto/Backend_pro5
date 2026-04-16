using System;
using System.Collections.Generic;
using System.Text;
using TiendaBatarazo.Dominio.Entidades;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class PedidoProveedor
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuarioSolicita { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalConIva { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relaciones
        public Proveedor Proveedor { get; set; }
        public Usuario UsuarioSolicita { get; set; }
        public ICollection<PedidoLinea> Lineas { get; set; }
    }
}
