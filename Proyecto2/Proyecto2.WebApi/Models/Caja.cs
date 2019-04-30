using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Caja
    {
        public int caja { get; set; }
        public int Monto { get; set; }
        public int Estado { get; set; }

        public Caja(int caja,int monto,int estado)
        {
            this.caja = caja;
            this.Monto = monto;
            this.Estado = estado;
        }
    }
}