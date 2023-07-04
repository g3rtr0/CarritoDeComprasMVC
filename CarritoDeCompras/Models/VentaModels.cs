using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarritoDeCompras.Models
{
    [Table("Venta")]
    public class VentaModels
    {
        public VentaModels()
        {
        }

        public VentaModels(ProductoModels productoModels, int cantidad)
        {
            this.producto = productoModels;
            this.Cantidad = cantidad;
        }

        [Key]
        public int Id { get; set; }

        public string Folio { get; set; }

        [NotMapped]
        public ProductoModels producto { get; set; }

        public List<ProductoModels> productoModels { get; set; }

        public string Usuario { get; set; }

        public DateTime DiaVenta { get; set; }
        public int Cantidad { get; set; }

        public decimal Total {  get; set; }
    }
}