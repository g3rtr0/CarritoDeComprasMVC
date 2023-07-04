using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarritoDeCompras.Models
{
    [Table("ListaVenta")]
    public class ListaVenta
    {
        [Key]
        public int Folio { get; set; }

        public ProductoModels Producto { get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }

        public ApplicationUser Usuario { get; set; }

        public DateTime DateTime { get; set; }
    }
}