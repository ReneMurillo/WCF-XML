using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteAspNet.Models;
using ClienteAspNet.ProductService;

namespace ClienteAspNet.Controllers
{
    public class CategoriasController : Controller
    {
        private ProductService.ServiceProductClient db = new ServiceProductClient();
        public ActionResult Index()
        {
            List<CategoriasView> categoriasView = new List<CategoriasView>();
            var categorias = db.ListarCategorias();
            foreach (var item in categorias)
            {
                var categoria = new CategoriasView
                {
                    CategoriaId = item.CategoriaId,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                };
                categoriasView.Add(categoria);
            }
            return View(categoriasView);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            var categoria = db.VerCategoria(id);

            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                var exito = db.CrearCategoria(categoria);

                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = db.VerCategoria(id);

            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                var exito = db.ActualizarCategoria(categoria);

                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = db.VerCategoria(id);

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categoria categoria)
        {
            try
            {
                var exito = db.EliminarCategoria(id);
                if (exito)
                    return RedirectToAction("Index");
                else
                    return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
    }
}
