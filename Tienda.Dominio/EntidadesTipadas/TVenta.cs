using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("ventas")]
    public class TVenta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("impuesto")]
        public decimal Impuesto { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        [Column("moneda")]
        public string Moneda { get; set; } = "CRC";

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        [Column("descuento")]
        public decimal Descuento { get; set; } = 0;
    }
}