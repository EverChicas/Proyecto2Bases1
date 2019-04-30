using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Cliente
    {
        public int DPI { get; set; }
        public string Nombre { get; set; }
        public int NIT { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}