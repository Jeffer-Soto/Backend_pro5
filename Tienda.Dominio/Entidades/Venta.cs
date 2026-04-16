using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Subtotal { get; set; }
        public string Moneda { get; set; } = "CRC";
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}