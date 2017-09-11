using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class CalleService : ICalleService
    {
        private ICalleRepository calleRepository;
        public CalleService(ICalleRepository _calleRepository)
        {
            this.calleRepository = _calleRepository;
        }

        public Calle Get(long id)
        {
            return calleRepository.Get(id);
        }

        public IQueryable<Calle> Get()
        {
            return calleRepository.Get();
        }

        public Calle Create(Calle calle)
        {
            return calleRepository.Create(calle);
        }

        public void Put(Calle calle)
        {
            calleRepository.Put(calle);
        }

        public Calle Delete(long id)
        {
            return calleRepository.Delete(id);
        }
    }
}