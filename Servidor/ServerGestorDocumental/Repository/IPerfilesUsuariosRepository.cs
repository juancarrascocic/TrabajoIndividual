using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Repository
{
    public interface IPerfilesUsuariosRepository
    {
        PerfilesUsuario Create(PerfilesUsuario perfilesUsuario);
        PerfilesUsuario Get(long id);
        IQueryable<PerfilesUsuario> Get();
        void Put(PerfilesUsuario perfilesUsuario);
        PerfilesUsuario Delete(long id);
    }
}
