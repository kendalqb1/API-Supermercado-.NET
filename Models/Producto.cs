using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supermercado.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public int IdCategoria { get; set; }
    }
}