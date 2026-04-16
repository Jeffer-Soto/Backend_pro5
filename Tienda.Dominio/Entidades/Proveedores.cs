using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Comic>? Comics { get; set; }
    }
}