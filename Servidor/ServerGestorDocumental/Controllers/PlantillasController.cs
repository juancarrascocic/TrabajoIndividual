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

    public class PlantillasController : ApiController
    {
        private IPlantillasService plantillasService;

        public PlantillasController(IPlantillasService _plantillasService)
        {
            this.plantillasService = _plantillasService;
        }

        // GET: api/Plantillas
        public IQueryable<Plantilla> GetPlantillas()
        {
            return plantillasService.Get();
        }

        // GET: api/Plantillas/5
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult GetPlantilla(long id)
        {
            Plantilla plantilla = plantillasService.Get(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return Ok(plantilla);
        }

        // PUT: api/Plantillas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantilla(long id, Plantilla plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantilla.Id)
            {
                return BadRequest();
            }

            try
            {
                plantillasService.Put(plantilla);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Plantillas
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult PostPlantilla(Plantilla plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            plantilla = plantillasService.Create(plantilla);

            return CreatedAtRoute("DefaultApi", new { id = plantilla.Id }, plantilla);
        }

        // DELETE: api/Plantillas/5
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult DeletePlantilla(long id)
        {
            Plantilla plantilla;
            try
            {
                plantilla = plantillasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(plantilla);
        }
    }
}