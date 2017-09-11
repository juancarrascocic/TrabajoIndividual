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

    public class CalleController : ApiController
    {
        private ICalleService calleService;

        public CalleController(ICalleService _calleService)
        {
            this.calleService = _calleService;
        }

        // GET: api/Calle
        public IQueryable<Calle> GetCalles()
        {
            return calleService.Get();
        }

        // GET: api/Calle/5
        [ResponseType(typeof(Calle))]
        public IHttpActionResult GetCalle(long id)
        {
            Calle calle = calleService.Get(id);
            if (calle == null)
            {
                return NotFound();
            }

            return Ok(calle);
        }

        // PUT: api/Calles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalles(long id, Calle calle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calle.Id)
            {
                return BadRequest();
            }

            try
            {
                calleService.Put(calle);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Calles
        [ResponseType(typeof(Calle))]
        public IHttpActionResult PostCalle(Calle calle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            calle = calleService.Create(calle);

            return CreatedAtRoute("DefaultApi", new { id = calle.Id }, calle);
        }

        // DELETE: api/Calles/5
        [ResponseType(typeof(Calle))]
        public IHttpActionResult DeleteCalle(long id)
        {
            Calle calle;
            try
            {
                calle = calleService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(calle);
        }
    }
}