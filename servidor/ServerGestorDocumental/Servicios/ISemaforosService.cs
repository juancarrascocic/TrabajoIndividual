using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Servicios
{
    public interface ISemaforosService
    {
        Semaforo Create(Semaforo semaforo);
        Semaforo Get(long id);
        IQueryable<Semaforo> Get();
        void Put(Semaforo semaforo);
        Semaforo Delete(long id);
    }
}
