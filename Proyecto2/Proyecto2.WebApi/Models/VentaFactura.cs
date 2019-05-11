using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class VentaFactura
    {
        public Venta venta { get; set; }
        public Factura factura { get; set; }

        public VentaFactura(Venta venta,Factura factura)
        {
            this.venta = venta;
            this.factura = factura;
        }

    }
}