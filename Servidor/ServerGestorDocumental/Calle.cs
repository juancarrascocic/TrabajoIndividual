using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Calle
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }
        public bool Circulable{ get; set; }
        public float? NumeroCarriles { get; set; }
        public float? AccidentesMensuales{ get; set; }
    }
}