using System;
using System.Collections.Generic;
using System.Text;


namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    public class TCliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Relaciones
        public ICollection<TPedido> Pedidos { get; set; }
    }
}
