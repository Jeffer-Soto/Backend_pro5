using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("detalle_venta")]
    public class TDetalleVenta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Column("id_comic")]
        public int IdComic { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("impuesto")]
        public decimal Impuesto { get; set; }

        [Column("descuento")]
        public decimal Descuento { get; set; } = 0;

        public TVenta Venta { get; set; } = null!;
        public TComic Comic { get; set; } = null!;
    }
}