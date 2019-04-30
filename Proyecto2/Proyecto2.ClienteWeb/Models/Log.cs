using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Log
    {
        public int log { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public int MontoMovimiento { get; set; }
        public int Movimiento { get; set; }
        public int Usuario { get; set; }
    }
}