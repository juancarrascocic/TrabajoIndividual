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

    public class SemaforosController : ApiController
    {
        private ISemaforosService semaforosService;

        public SemaforosController(ISemaforosService _semaforosService)
        {
            this.semaforosService = _semaforosService;
        }

        // GET: api/Semaforos
        public IQueryable<Semaforo> GetPlantillas()
        {
            return semaforosService.Get();
        }

        // GET: api/Semaforos/5
        [ResponseType(typeof(Semaforo))]
        public IHttpActionResult GetPlantilla(long id)
        {
            Semaforo plantilla = semaforosService.Get(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return Ok(plantilla);
        }

        // PUT: api/Semaforos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantilla(long id, Semaforo semaforo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != semaforo.Id)
            {
                return BadRequest();
            }

            try
            {
                semaforosService.Put(semaforo);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Semaforos
        [ResponseType(typeof(Semaforo))]
        public IHttpActionResult PostPlantilla(Semaforo semaforo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            semaforo = semaforosService.Create(semaforo);

            return CreatedAtRoute("DefaultApi", new { id = semaforo.Id }, semaforo);
        }

        // DELETE: api/Semaforos/5
        [ResponseType(typeof(Semaforo))]
        public IHttpActionResult DeletePlantilla(long id)
        {
            Semaforo semaforo;
            try
            {
                semaforo = semaforosService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(semaforo);
        }
    }
}