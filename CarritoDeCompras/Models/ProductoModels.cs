using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarritoDeCompras.Models
{
    [Table("Producto")]
    public class ProductoModels
    {
        public IEnumerable<ProductoModels> ListaProductos { get; set; }

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }

        public string ImagenUrl { get; set; }
        public string Codigo { get; set; }


        public string Descripcion { get; set; }
        public int Stock { get; set; }


        public string Fabricante { get; set; }

        public string Categoria { get; set; }

    }
}