using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Servicios
{
    public interface ICalleService
    {
        Calle Create(Calle calle);
        Calle Get(long id);
        IQueryable<Calle> Get();
        void Put(Calle calle);
        Calle Delete(long id);
    }
}
