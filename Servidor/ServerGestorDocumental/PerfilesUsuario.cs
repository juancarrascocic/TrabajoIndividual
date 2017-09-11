using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class PerfilesUsuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Permisos { get; set; }
        public string ExtCorreoE { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
    }
}