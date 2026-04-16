using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class DireccionEnvio
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NombreContacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string DireccionExacta { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string? Referencias { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Usuario Usuario { get; set; } = null!;
    }
}
