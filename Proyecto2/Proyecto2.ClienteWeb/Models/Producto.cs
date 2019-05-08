using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Producto
    {
        public int producto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        //VARIABLE UNIDADES_DISPONBLES AGREGADA POR BRANDON
        public int unidades_disponibles { get; set; }
    }
}