using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class PlantillasRepository : IPlantillasRepository
    {
        public Plantilla Create(Plantilla plantilla)
        {
            return ApplicationDbContext.applicationDbContext.Plantillas.Add(plantilla);
        }

        public Plantilla Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Plantillas.Find(id);
        }

        public IQueryable<Plantilla> Get()
        {
            IList<Plantilla> lista = new List<Plantilla>(ApplicationDbContext.applicationDbContext.Plantillas);

            return lista.AsQueryable();
        }


        public void Put(Plantilla plantilla)
        {
            if (ApplicationDbContext.applicationDbContext.Plantillas.Count(e => e.Id == plantilla.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(plantilla).State = EntityState.Modified;
        }

        public Plantilla Delete(long id)
        {
            Plantilla plantilla = ApplicationDbContext.applicationDbContext.Plantillas.Find(id);
            if (plantilla == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Plantillas.Remove(plantilla);
            return plantilla;
        }
    }
}