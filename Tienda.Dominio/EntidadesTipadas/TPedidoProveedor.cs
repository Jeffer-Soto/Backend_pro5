using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("pedidos_proveedores")]
    public class TPedidoProveedor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        [Column("id_usuario_solicita")]
        public int IdUsuarioSolicita { get; set; }

        [Column("notas")]
        public string? Notas { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        [Column("total_net")]
        public decimal TotalNet { get; set; }

        [Column("total_iva")]
        public decimal TotalIva { get; set; }

        [Column("total_con_iva")]
        public decimal TotalConIva { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TProveedor Proveedor { get; set; } = null!;
        public TUsuario UsuarioSolicita { get; set; } = null!;
        public ICollection<TPedidoLinea> Lineas { get; set; } = new List<TPedidoLinea>();
    }
}