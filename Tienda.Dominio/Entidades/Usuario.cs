using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = "cliente";
        public DateTime CreadoEn { get; set; } = DateTime.Now;

        public ICollection<Venta>? Ventas { get; set; }
    }
}