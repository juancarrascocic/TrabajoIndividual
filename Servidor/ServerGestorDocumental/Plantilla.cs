using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Plantilla
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Estilo { get; set; }
        public string Tipo { get; set; }
        public bool Accesibilidad { get; set; }
        public float Precio { get; set; }

    }
}