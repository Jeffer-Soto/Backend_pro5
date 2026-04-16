using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class DetallesPedido
    {
        public int DetalleId { get; set; }
        public int PedidoId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Relaciones
        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
