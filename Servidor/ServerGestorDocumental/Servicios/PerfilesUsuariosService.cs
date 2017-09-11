using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class PerfilesUsuariosService : IPerfilesUsuariosService
    {
        private IPerfilesUsuariosRepository perfilesUsuariosRepository;
        public PerfilesUsuariosService(IPerfilesUsuariosRepository _perfilesUsuariosRepository)
        {
            this.perfilesUsuariosRepository = _perfilesUsuariosRepository;
        }

        public PerfilesUsuario Get(long id)
        {
            return perfilesUsuariosRepository.Get(id);
        }

        public IQueryable<PerfilesUsuario> Get()
        {
            return perfilesUsuariosRepository.Get();
        }

        public PerfilesUsuario Create(PerfilesUsuario perfilesUsuario)
        {
            return perfilesUsuariosRepository.Create(perfilesUsuario);
        }

        public void Put(PerfilesUsuario perfilesUsuario)
        {
            perfilesUsuariosRepository.Put(perfilesUsuario);
        }

        public PerfilesUsuario Delete(long id)
        {
            return perfilesUsuariosRepository.Delete(id);
        }
    }
}