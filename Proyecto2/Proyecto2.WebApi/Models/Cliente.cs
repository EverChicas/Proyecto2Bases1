using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Cliente
    {
        public int DPI { get; set; }
        public string Nombre { get; set; }
        public int NIT { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Cliente(int DPI,string Nombre,int NTI,string Telefono,string Correo)
        {
            this.DPI = DPI;
            this.Nombre = Nombre;
            this.NIT = NIT;
            this.Telefono = Telefono;
            this.Correo = Correo;
        }
    }
}