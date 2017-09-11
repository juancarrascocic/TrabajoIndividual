using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class SemaforosRepository : ISemaforosRepository
    {
        public Semaforo Create(Semaforo semaforo)
        {
            return ApplicationDbContext.applicationDbContext.Semaforos.Add(semaforo);
        }

        public Semaforo Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Semaforos.Find(id);
        }

        public IQueryable<Semaforo> Get()
        {
            IList<Semaforo> lista = new List<Semaforo>(ApplicationDbContext.applicationDbContext.Semaforos);

            return lista.AsQueryable();
        }


        public void Put(Semaforo semaforo)
        {
            if (ApplicationDbContext.applicationDbContext.Semaforos.Count(e => e.Id == semaforo.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(semaforo).State = EntityState.Modified;
        }

        public Semaforo Delete(long id)
        {
            Semaforo semaforo = ApplicationDbContext.applicationDbContext.Semaforos.Find(id);
            if (semaforo == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Semaforos.Remove(semaforo);
            return semaforo;
        }
    }
}