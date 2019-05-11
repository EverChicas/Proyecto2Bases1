using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class VentaFactura
    {
        public Venta venta { get; set; }
        public Factura factura { get; set; }
    }
}