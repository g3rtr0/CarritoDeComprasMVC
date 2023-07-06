using CarritoDeCompras.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoDeCompras.Controllers
{
    public class CarroComprasController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: CarroCompras
        public ActionResult Index()
        {
            return View();
        }

        public CarroComprasController()
        {

        }
        public CarroComprasController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult AgregarAlCarro(int id)
        {
            if (Session["carrito"] == null)
            {
                List<VentaModels> compras = new List<VentaModels>();
                compras.Add(new VentaModels(_db.Producto.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<VentaModels> compras = (List<VentaModels>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new VentaModels(_db.Producto.Find(id), 1));
                else
                    compras[IndexExistente].Cantidad++;
                Session["carrito"] = compras;

            }
            return RedirectToAction("Index", "Home");
        }

        //private void DisminuirStockEnCarrito(List<VentaModels> carrito)
        //{
        //    foreach (VentaModels venta in carrito)
        //    {
        //        int idProducto = venta.producto.Id;
        //        int cantidad = venta.Cantidad;
        //        int agregar = 1;
        //        ProductoModels producto = _db.Producto.Find(idProducto);
        //        producto.Stock -= cantidad;
        //        producto.Stock += agregar;
        //    }

        //    _db.SaveChanges(); // Guardar los cambios en la base de datos
        //}
        public ActionResult FinalizarCompra()
        {
            return View();
        }

        public ActionResult Create(VentaModels venta)
        {
            if (ModelState.IsValid)
            {
                _db.Venta.Add(venta);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            List<VentaModels> compras = (List<VentaModels>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return Redirect(Request.UrlReferrer.ToString());
        }
        private int getIndex(int id)
        {
            List<VentaModels> compras = (List<VentaModels>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].producto.Id == id)
                    return i;
            }
            return -1;
        }
        public ActionResult insertarVenta()
        {
            List<VentaModels> lista = (List<VentaModels>)Session["carrito"];
            if (lista != null && lista.Any())
            {
                double total = (double)lista.Sum(p => p.Total);
                int cantidad = 0;
                foreach (var item in lista)
                {
                    total += (double)(item.Cantidad * item.producto.Precio);
                }
                VentaModels venta = new VentaModels()
                {
                    Usuario = User.Identity.GetUserName(),
                    DiaVenta = DateTime.Now,
                    Cantidad = cantidad,
                    Total = (decimal)total,

                };
                Session.Remove("carrito");
                _db.Venta.Add(venta);
                _db.SaveChanges();
            }

            return View();
        }
        public ActionResult VentaFinalizada()
        {
            return View();
        }
    }
}