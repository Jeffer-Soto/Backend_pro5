using System;
using System.Collections.Generic;
using System.Text;
using TiendaBatarazo.Dominio.Entidades;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class PedidoLinea
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdComic { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioUnitarioNet { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SubtotalNet { get; set; }
        public decimal SubtotalConIva { get; set; }

        // Relaciones
        public PedidoProveedor Pedido { get; set; }
        public Comic Comic { get; set; }
    }
}
