using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Movimiento
    {
        public int movimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public double SaldoCaja { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }
    }
}