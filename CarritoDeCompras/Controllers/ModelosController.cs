using CarritoDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoDeCompras.Controllers
{
    public class ModelosController : Controller
    {
        // GET: Modelos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MiAccion()
        {
            var modelo = new Modelos()
            {
                Producto = new ProductoModels(),
                Productos = ObtenerModelo()
            };
            return View(modelo);
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