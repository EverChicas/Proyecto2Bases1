using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Factura
    {
        public int factura { get; set; }
        public DateTime FechaHora { get; set; }
        public int Cliente { get; set; }
        public int NIT { get; set; }
        public int Total { get; set; }
        public int IVA_Venta { get; set; }
    }
}