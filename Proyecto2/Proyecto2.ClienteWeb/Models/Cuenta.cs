using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Cuenta
    {
        public int cuenta { get; set; }
        public int NoFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public double TotalFactura { get; set; }
        public double SaldoFactura { get; set; }
        public int Cliente { get; set; }
        public int EstadoCuenta { get; set; }
    }
}