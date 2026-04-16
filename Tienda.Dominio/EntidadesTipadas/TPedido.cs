using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    public class TPedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }

        // Relaciones
        public TCliente Cliente { get; set; }
    }
}
