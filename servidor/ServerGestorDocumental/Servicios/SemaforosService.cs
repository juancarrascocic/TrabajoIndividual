using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class SemaforosService : ISemaforosService
    {
        private ISemaforosRepository semaforosRepository;
        public SemaforosService(ISemaforosRepository _plantillasRepository)
        {
            this.semaforosRepository = _plantillasRepository;
        }

        public Semaforo Get(long id)
        {
            return semaforosRepository.Get(id);
        }

        public IQueryable<Semaforo> Get()
        {
            return semaforosRepository.Get();
        }

        public Semaforo Create(Semaforo semaforo)
        {
            return semaforosRepository.Create(semaforo);
        }

        public void Put(Semaforo semaforo)
        {
            semaforosRepository.Put(semaforo);
        }

        public Semaforo Delete(long id)
        {
            return semaforosRepository.Delete(id);
        }
    }
}