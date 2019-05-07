﻿using System;
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
        public double Total { get; set; }
        public double IVA_Venta { get; set; }
    }
}