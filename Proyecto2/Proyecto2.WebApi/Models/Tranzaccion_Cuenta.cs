using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Tranzaccion_Cuenta
    {
        public int TranzaccionCuenta { get; set; }
        public int Monto { get; set; }
        public int Cuenta { get; set; }
        public int Tipo_Tranzaccion { get; set; }

        public Tranzaccion_Cuenta(int TranzaccionCuenta,int monto,int cuenta,int tipoTranzaccion)
        {
            this.TranzaccionCuenta = TranzaccionCuenta;
            this.Monto = monto;
            this.Cuenta = cuenta;
            this.Tipo_Tranzaccion = tipoTranzaccion;
        }

    }
}