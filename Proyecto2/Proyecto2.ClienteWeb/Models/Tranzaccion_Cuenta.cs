using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Tranzaccion_Cuenta
    {
        public int TranzaccionCuenta { get; set; }
        public int Monto { get; set; }
        public int Cuenta { get; set; }
        public int Tipo_Tranzaccion { get; set; }
    }
}