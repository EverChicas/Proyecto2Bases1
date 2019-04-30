using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Proveedor
    {
        public int proveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Proveedor(int proveedor,string nombre,string direccion,string correo,string telefono)
        {
            this.proveedor = proveedor;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Correo = correo;
            this.Telefono = telefono;
        }
    }
}