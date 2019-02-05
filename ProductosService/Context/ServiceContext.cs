using ProductosService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductosService.Context
{
    public class ServiceContext: DbContext
    {
        public ServiceContext(): base("name=ConnectionError")
        {

        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }
    }
}