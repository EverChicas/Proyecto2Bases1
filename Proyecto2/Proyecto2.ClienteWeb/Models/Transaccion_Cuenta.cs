using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class Transaccion_Cuenta
    {
        public int TransaccionCuenta { get; set; }
        public double Monto { get; set; }
        public int Cuenta { get; set; }
        public int Tipo_Tranzaccion { get; set; }
    }
}