using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;

namespace formulario.Models
{
    // Para agregar datos de perfil al usuario, agregue más propiedades a la clase ApplicationUser. Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        [ThreadStatic]
        public static ApplicationDbContext applicationDbContext;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Calle> Calle { get; set; }

        public static ApplicationDbContext CreateCalleDB()
        {
            return new ApplicationDbContext();
        }

        public DbSet<PerfilesUsuario> PerfilesUsuarios { get; set; }

        public static ApplicationDbContext CreatePerfilesUsuariosDB()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Semaforo> Semaforos { get; set; }

        public static ApplicationDbContext CreateSemaforosDB()
        {
            return new ApplicationDbContext();
        }

        public DbSet<KeepAlive> KeepAlives { get; set; }
    }
}