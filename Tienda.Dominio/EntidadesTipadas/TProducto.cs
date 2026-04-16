using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    public class TProducto
    {
        public string ProductoId { get; set; } = string.Empty;  // ✅ string
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public TCategoria Categoria { get; set; } = null!;
    }
}
