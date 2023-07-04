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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            List<ProductoModels> productos;
            using (var db = new ApplicationDbContext())
            {
                productos = db.Producto.ToList();
            }
            return View(productos);
        }

        public IEnumerable<CarritoDeCompras.Models.ProductoModels> ObtenerModelo()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var productos = dbContext.Producto.ToList();

                var modeloProductos = productos.Select(p => new CarritoDeCompras.Models.ProductoModels
                {
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Fabricante = p.Fabricante,
                    Categoria = p.Categoria,
                    Codigo = p.Codigo,
                    Stock = p.Stock,
                    Id = p.Id
                });

                return modeloProductos;
            }
        }
    }
}