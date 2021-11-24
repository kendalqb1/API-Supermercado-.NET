using Supermercado.Models;
using Supermercado.Services;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Supermercado.Controllers
{
    public class ProductosController : ApiController
    {
     
        [HttpGet]
        public List<Producto> listaProductos()
        {
            return ProductoService.getAll();
        }

        [HttpGet]
        public Producto listarProductoById(int id)
        {
            return ProductoService.getProductoByID(id);
        }

    }
}
