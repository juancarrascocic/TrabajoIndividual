using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Servicios
{
    public interface IPerfilesUsuariosService
    {
        PerfilesUsuario Create(PerfilesUsuario perfilesUsuario);
        PerfilesUsuario Get(long id);
        IQueryable<PerfilesUsuario> Get();
        void Put(PerfilesUsuario perfilesUsuario);
        PerfilesUsuario Delete(long id);
    }
}
