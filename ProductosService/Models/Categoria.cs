using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductosService.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

    }
}