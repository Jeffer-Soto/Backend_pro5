using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("comics")]
    public class TComic
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("numero_saga")]
        public string? NumeroSaga { get; set; }

        [Column("edicion")]
        public string? Edicion { get; set; }

        [Column("portada")]
        public string? Portada { get; set; }

        [Column("version")]
        public string Version { get; set; } = "normal";

        [Column("valor_base")]
        public decimal ValorBase { get; set; }

        [Column("precio_final")]
        public decimal PrecioFinal { get; set; }

        [Column("stock")]
        public int Stock { get; set; } = 0;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}