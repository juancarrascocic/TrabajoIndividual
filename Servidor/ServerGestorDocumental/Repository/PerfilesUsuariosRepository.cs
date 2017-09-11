using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class PerfilesUsuariosRepository : IPerfilesUsuariosRepository
    {
        public PerfilesUsuario Create(PerfilesUsuario perfilesUsuario)
        {
            return ApplicationDbContext.applicationDbContext.PerfilesUsuarios.Add(perfilesUsuario);
        }

        public PerfilesUsuario Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.PerfilesUsuarios.Find(id);
        }

        public IQueryable<PerfilesUsuario> Get()
        {
            IList<PerfilesUsuario> lista = new List<PerfilesUsuario>(ApplicationDbContext.applicationDbContext.PerfilesUsuarios);

            return lista.AsQueryable();
        }


        public void Put(PerfilesUsuario perfilesUsuario)
        {
            if (ApplicationDbContext.applicationDbContext.PerfilesUsuarios.Count(e => e.Id == perfilesUsuario.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(perfilesUsuario).State = EntityState.Modified;
        }

        public PerfilesUsuario Delete(long id)
        {
            PerfilesUsuario perfilesUsuario = ApplicationDbContext.applicationDbContext.PerfilesUsuarios.Find(id);
            if (perfilesUsuario == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.PerfilesUsuarios.Remove(perfilesUsuario);
            return perfilesUsuario;
        }
    }
}