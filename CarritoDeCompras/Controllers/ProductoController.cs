using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarritoDeCompras.Models;

namespace CarritoDeCompras.Controllers
{
    public class ProductoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ProductoModels prod = new ProductoModels();

        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Producto.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Precio,ImagenUrl,Codigo,Descripcion,Stock,Fabricante,Categoria")] ProductoModels productoModels, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.ContentLength > 0)
                {
                    // Guardar el archivo en una ubicación específica
                    string rutaImagen = "~/img/Productos/" + Path.GetFileName(imagen.FileName);
                    imagen.SaveAs(Server.MapPath(rutaImagen));

                    // Guardar la URL de la imagen en el atributo ImagenUrl
                    productoModels.ImagenUrl = rutaImagen;
                }
                db.Producto.Add(productoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoModels);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Producto.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Precio,FechaCreacion,ImagenUrl,CategoriaId,Codigo,Descripcion,Stock,Fabricante,Categoria")] ProductoModels productoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoModels);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModels productoModels = db.Producto.Find(id);
            if (productoModels == null)
            {
                return HttpNotFound();
            }
            return View(productoModels);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoModels productoModels = db.Producto.Find(id);
            db.Producto.Remove(productoModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
