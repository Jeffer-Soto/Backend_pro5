using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class Comic
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? NumeroSaga { get; set; }
        public string? Edicion { get; set; }
        public string? Portada { get; set; }
        public string Version { get; set; } = "normal";
        public decimal ValorBase { get; set; }
        public decimal PrecioFinal { get; set; }
        public int Stock { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Proveedor Proveedor { get; set; } = null!;
    }
}
