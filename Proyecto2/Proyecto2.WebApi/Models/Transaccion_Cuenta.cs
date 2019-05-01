using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Transaccion_Cuenta
    {
        public int TransaccionCuenta { get; set; }
        public int Monto { get; set; }
        public int Cuenta { get; set; }
        public int Tipo_Transaccion { get; set; }

        public Transaccion_Cuenta(int TransaccionCuenta,int monto,int cuenta,int tipoTransaccion)
        {
            this.TransaccionCuenta = TransaccionCuenta;
            this.Monto = monto;
            this.Cuenta = cuenta;
            this.Tipo_Transaccion = tipoTransaccion;
        }

    }
}