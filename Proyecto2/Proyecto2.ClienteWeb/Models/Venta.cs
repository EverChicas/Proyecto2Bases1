using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Venta
    {
        public int venta { get; set; }
        public int NIT { get; set; }
        public string NombreCliente { get; set; }
        public int IVA { get; set; }
        public int MontoPagado { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }
        public int Factura { get; set; }
    }
}