using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Estado_Cuenta
    {
        public int EstadoCuenta { get; set; }
        public string Nombre { get; set; }

        public Estado_Cuenta(int EstadoCuenta, string nombre)
        {
            this.EstadoCuenta = EstadoCuenta;
            this.Nombre = nombre;
        }
    }
}