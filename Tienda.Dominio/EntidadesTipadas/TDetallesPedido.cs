using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("detalles_pedido")]
    public class TDetallesPedido
    {
        [Column("detalle_id")]
        public int DetalleId { get; set; }

        [Column("id_pedido")]
        public int PedidoId { get; set; }

        [Column("id_producto")]
        public int ProductoId { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

        public TPedido Pedido { get; set; }
        public TProducto Producto { get; set; }
    }
}