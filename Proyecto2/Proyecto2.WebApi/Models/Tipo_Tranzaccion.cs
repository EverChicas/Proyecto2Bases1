using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Tipo_Tranzaccion
    {
        public int TipoTranzaccion { get; set; }
        public string Nombre { get; set; }

        public Tipo_Tranzaccion(int TipoTranzaccion,string nombre)
        {
            this.TipoTranzaccion = TipoTranzaccion;
            this.Nombre = nombre;
        }
    }
}