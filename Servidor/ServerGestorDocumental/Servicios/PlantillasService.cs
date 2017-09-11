using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class PlantillasService : IPlantillasService
    {
        private IPlantillasRepository plantillasRepository;
        public PlantillasService(IPlantillasRepository _plantillasRepository)
        {
            this.plantillasRepository = _plantillasRepository;
        }

        public Plantilla Get(long id)
        {
            return plantillasRepository.Get(id);
        }

        public IQueryable<Plantilla> Get()
        {
            return plantillasRepository.Get();
        }

        public Plantilla Create(Plantilla plantilla)
        {
            return plantillasRepository.Create(plantilla);
        }

        public void Put(Plantilla plantilla)
        {
            plantillasRepository.Put(plantilla);
        }

        public Plantilla Delete(long id)
        {
            return plantillasRepository.Delete(id);
        }
    }
}