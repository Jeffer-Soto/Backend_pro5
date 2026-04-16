using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaBatarazo.Dominio.EntidadesTipadas
{
    public class TCategoria
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

        // Relaciones
        public ICollection<TProducto> Productos { get; set; }
    }
}
