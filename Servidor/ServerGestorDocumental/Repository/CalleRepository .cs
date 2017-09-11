using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class CalleRepository : ICalleRepository
    {
        public Calle Create(Calle calle)
        {
            return ApplicationDbContext.applicationDbContext.Calle.Add(calle);
        }

        public Calle Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Calle.Find(id);
        }

        public IQueryable<Calle> Get()
        {
            IList<Calle> lista = new List<Calle>(ApplicationDbContext.applicationDbContext.Calle);

            return lista.AsQueryable();
        }


        public void Put(Calle calle)
        {
            if (ApplicationDbContext.applicationDbContext.Calle.Count(e => e.Id == calle.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(calle).State = EntityState.Modified;
        }

        public Calle Delete(long id)
        {
            Calle calle = ApplicationDbContext.applicationDbContext.Calle.Find(id);
            if (calle == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Calle.Remove(calle);
            return calle;
        }
    }
}