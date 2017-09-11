using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using formulario;
using formulario.Models;
using formulario.Servicios;
using System.Web.Http.Cors;

namespace formulario.Controllers
{
    [EnableCors(origins: "http://localhost:8080, http://localhost:8081, http://localhost:3000", headers: "*", methods: "*")]

    public class PerfilesUsuariosController : ApiController
    {
        private IPerfilesUsuariosService perfilesUsuariosService;

        public PerfilesUsuariosController(IPerfilesUsuariosService _perfilesUsuariosService)
        {
            this.perfilesUsuariosService = _perfilesUsuariosService;
        }

        // GET: api/PerfilesUsuarios
        public IQueryable<PerfilesUsuario> GetPerfilesUsuarios()
        {
            return perfilesUsuariosService.Get();
        }

        // GET: api/PerfilesUsuarios/5
        [ResponseType(typeof(PerfilesUsuario))]
        public IHttpActionResult GetPerfilesUsuario(long id)
        {
            PerfilesUsuario perfilesUsuario = perfilesUsuariosService.Get(id);
            if (perfilesUsuario == null)
            {
                return NotFound();
            }

            return Ok(perfilesUsuario);
        }

        // PUT: api/PerfilesUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfilesUsuario(long id, PerfilesUsuario perfilesUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfilesUsuario.Id)
            {
                return BadRequest();
            }

            try
            {
                perfilesUsuariosService.Put(perfilesUsuario);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PerfilesUsuarios
        [ResponseType(typeof(PerfilesUsuario))]
        public IHttpActionResult PostPerfilesUsuario(PerfilesUsuario perfilesUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            perfilesUsuario = perfilesUsuariosService.Create(perfilesUsuario);

            return CreatedAtRoute("DefaultApi", new { id = perfilesUsuario.Id }, perfilesUsuario);
        }

        // DELETE: api/PerfilesUsuarios/5
        [ResponseType(typeof(PerfilesUsuario))]
        public IHttpActionResult DeletePerfilesUsuario(long id)
        {
            PerfilesUsuario perfilesUsuario;
            try
            {
                perfilesUsuario = perfilesUsuariosService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(perfilesUsuario);
        }
    }
}