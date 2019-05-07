using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Compra
    {
        public int compra { get; set; }
        public DateTime Fecha { get; set; }
        public double PrecioUnidad { get; set; }
        public double ValorCompra { get; set; }
        public int Cantidad { get; set; }
        public int NoFactura { get; set; }
        public int Producto { get; set; }
        public int Proveedor { get; set; }
        public int Usuario { get; set; }
    }
}