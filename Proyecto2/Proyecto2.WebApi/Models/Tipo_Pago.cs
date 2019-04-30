using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Tipo_Pago
    {
        public int TipoPago { get; set; }
        public string Nombre { get; set; }

        public Tipo_Pago(int tipoPago,string nombre)
        {
            this.TipoPago = tipoPago;
            this.Nombre = nombre;
        }
    }
}