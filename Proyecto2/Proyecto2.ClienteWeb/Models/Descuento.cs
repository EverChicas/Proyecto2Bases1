using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Descuento
    {
        public int descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int PorcentajeDescuento { get; set; }
        public int Producto { get; set; }
        public string nombreProducto { get; set; }
    }
}