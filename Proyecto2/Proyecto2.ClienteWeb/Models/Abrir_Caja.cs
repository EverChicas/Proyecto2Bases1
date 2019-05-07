using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Abrir_Caja
    {
        public DateTime FechaHora { get; set; }
        public double Monto { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }
    }
}