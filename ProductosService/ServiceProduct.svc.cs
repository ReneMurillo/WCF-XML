using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProductosService.Context;
using ProductosService.Models;

namespace ProductosService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProduct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProduct.svc or ServiceProduct.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {
        private ServiceContext db = new ServiceContext();
        public bool ActualizarCategoria(Categoria categoria)
        {
            try
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CrearCategoria(Categoria categoria)
        {
            try
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CrearProducto(Producto producto)
        {
            try
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarCategoria(int id)
        {
            try
            {
                var categoria = db.Categorias.Find(id);
                db.Categorias.Remove(categoria);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarProducto(int id)
        {
            try
            {
                var producto = db.Productos.Find(id);
                db.Productos.Remove(producto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Producto> Filtrar(string parametro)
        {
            var listado = (from p in db.Productos
                           where p.Nombre.Contains(parametro)
                           select p).ToList();

            return listado;
        }

        public List<Categoria> ListarCategorias()
        {
            return db.Categorias.ToList();
        }

        public List<Producto> ListarProductos()
        {
            return db.Productos.ToList();
        }

        public Categoria VerCategoria(int id)
        {
            var categoria = db.Categorias.Find(id);
            return categoria;
        }

        public Producto VerProducto(int id)
        {
            var producto = db.Productos.Find(id);
            return producto;
        }
    }
}
