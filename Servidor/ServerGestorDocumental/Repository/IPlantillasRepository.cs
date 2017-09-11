using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Repository
{
    public interface IPlantillasRepository
    {
        Plantilla Create(Plantilla plantilla);
        Plantilla Get(long id);
        IQueryable<Plantilla> Get();
        void Put(Plantilla plantilla);
        Plantilla Delete(long id);
    }
}
