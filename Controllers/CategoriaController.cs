using Supermercado.Models;
using Supermercado.Services;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace Supermercado.Controllers
{
    public class CategoriaController : ApiController
    {
        public CategoriaController()
        {
        }

        [HttpGet]
        public List<Categoria> GetAllCategorias()
        {
            List<Categoria> categorias = CategoriaService.GetAll();
            return categorias;
        }

        [HttpGet]
        public HttpResponseMessage GetCaetegoriaById(int id)
        {
            Categoria categoria = CategoriaService.GetItem(id);
            if (categoria.NombreCategoria != null)
                return Request.CreateResponse(HttpStatusCode.OK, categoria);
            return Request.CreateResponse(HttpStatusCode.NotFound, "Categoria no encontrada");

        }

        [HttpPost]
        public HttpResponseMessage AddCategoria([FromBody]Categoria cat)
        {
            bool agregado =  CategoriaService.Add(cat);
            if (agregado)
                return Request.CreateResponse(HttpStatusCode.OK, "Categoria Agregada");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No se puedo agregar, intentelo nuevamente");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCategoria(int id)
        {
            bool eliminado =  CategoriaService.Delete(id);
            if (eliminado)
                return Request.CreateResponse(HttpStatusCode.OK, "Categoria Eliminada");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No se puedo eliminar, intentelo nuevamente");
        }

        [HttpPut]
        public HttpResponseMessage UpdateCategoria(int id, [FromBody]Categoria cat)
        {
            bool actulizado =  CategoriaService.Update(id, cat);
            if (actulizado)
                return Request.CreateResponse(HttpStatusCode.OK, "Categoria Actualizada");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No se puedo actualizar, intentelo nuevamente");

        }
    }
}
