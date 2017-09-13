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
using System.Web.Http.Cors;

namespace formulario.Controllers
{
    public class KeepAlivesController : ApiController
    {
        [EnableCors(origins: "http://localhost:8080, http://localhost:8081, http://localhost:3000", headers: "*", methods: "*")]
        // GET: api/KeepAlives
        public IHttpActionResult GetKeepAlives()
        {
            return Ok();
        }
        
    }
}