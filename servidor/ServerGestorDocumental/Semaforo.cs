using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Semaforo
    {
        public long Id { get; set; }
        public float TiempoVerde { get; set; }
        public float TiempoRojo { get; set; }
        public string Calle { get; set; }
        public bool PasoPeatones { get; set; }

    }
}