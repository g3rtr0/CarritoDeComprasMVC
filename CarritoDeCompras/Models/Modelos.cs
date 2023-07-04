using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoDeCompras.Models
{
    public class Modelos
    {
        public ProductoModels Producto { get; set; }
        public IEnumerable<ProductoModels> Productos { get; set; }
    }
}