using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarritoDeCompras.Models
{
    [Table("Categoria")]
    public class CategoriaModels
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}