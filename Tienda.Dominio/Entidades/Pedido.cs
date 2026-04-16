using System;
using System.Collections.Generic;
using System.Text;


namespace TiendaBatarazo.Dominio.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; }
        public ICollection<DetallesPedido> Detalles { get; set; }
    }
}
