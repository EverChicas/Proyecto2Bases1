using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Cerrar_Caja
    {
        public DateTime FechaHora { get; set; }
        public double MontoNumero { get; set; }
        public string MontoLetras { get; set; }
        public string Observacion { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }
    }
}