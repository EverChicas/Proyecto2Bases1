using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Detalle
    {
        public int Factura { get; set; }
        public int Producto { get; set; }
        public int Cliente { get; set; }
        public double PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
    }
}