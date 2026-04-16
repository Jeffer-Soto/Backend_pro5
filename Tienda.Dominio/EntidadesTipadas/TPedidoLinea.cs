using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("pedido_lineas")]
    public class TPedidoLinea
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Column("id_comic")]
        public int IdComic { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

        [Column("precio_unitario_net")]
        public decimal PrecioUnitarioNet { get; set; }

        [Column("iva")]
        public decimal Iva { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("subtotal_net")]
        public decimal SubtotalNet { get; set; }

        [Column("subtotal_con_iva")]
        public decimal SubtotalConIva { get; set; }

        [Column("descuento")]
        public decimal Descuento { get; set; } = 0;
        public TPedidoProveedor Pedido { get; set; } = null!;
        public TComic Comic { get; set; } = null!;
    }
}