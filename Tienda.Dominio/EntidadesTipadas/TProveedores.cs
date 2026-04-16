using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("proveedores")]
    public class TProveedor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("correo")]
        public string? Correo { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}