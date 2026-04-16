using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.Entidades
{
    public class Producto
    {
        public string ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        // Relaciones
        public Categoria Categoria { get; set; }
        public ICollection<DetallesPedido> DetallesPedidos { get; set; }
    }
}
