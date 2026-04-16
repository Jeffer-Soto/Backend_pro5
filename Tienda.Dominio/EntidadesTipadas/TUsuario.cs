using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    [Table("usuarios")]
    public class TUsuario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario")]
        public string UsuarioNombre { get; set; } = string.Empty;

        [Column("correo")]
        public string Correo { get; set; } = string.Empty;

        [Column("fechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("clave")]
        public string Clave { get; set; } = string.Empty;

        [Column("rol")]
        public string Rol { get; set; } = "cliente";

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; } = DateTime.Now;

        [Column("edad")]
        public int Edad { get; set; }
    }
}