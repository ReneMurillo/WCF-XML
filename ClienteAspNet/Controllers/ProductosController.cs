using ClienteAspNet.Models;
using ClienteAspNet.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteAspNet.Controllers
{
    public class ProductosController : Controller
    {
        private ProductService.ServiceProductClient db = new ServiceProductClient();
        // GET: Productos
        public ActionResult Index()
        {
            List<ProductosView> productosView = new List<ProductosView>();
            var productos = db.ListarProductos();
            foreach (var item in productos)
            {
                var producto = new ProductosView
                {
                    ProductoId = item.ProductoId,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Stock = item.Stock
                };
                productosView.Add(producto);
            }
            return View(productosView);
        }

        [HttpPost]
        public ActionResult Index(string Parametro)
        {
            List<ProductosView> productosView = new List<ProductosView>();
            var productos = db.Filtrar(Parametro);
            foreach (var item in productos)
            {
                var producto = new ProductosView
                {
                    ProductoId = item.ProductoId,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Stock = item.Stock
                };
                productosView.Add(producto);
            }
            return View(productosView);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            var producto = db.VerProducto(id);

            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                var exito = db.CrearProducto(producto);

                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = db.VerProducto(id);

            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                var exito = db.ActualizarProducto(producto);

                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = db.VerProducto(id);

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Producto producto)
        {
            try
            {
                var exito = db.EliminarProducto(id);
                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }
    }
}
