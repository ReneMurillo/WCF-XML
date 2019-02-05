using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductosService.Models
{
    public class CategoriaProductoView
    {
        public int CategoriaId { get; set; }

        public string NombreCategoria { get; set; }

        public string Descripcion { get; set; }

        public int ProductoId { get; set; }

        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

    }
}