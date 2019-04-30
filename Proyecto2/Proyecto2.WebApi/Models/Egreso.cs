using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Egreso
    {
        public int egreso { get; set; }
        public DateTime FechaHora { get; set; }
        public int Monto { get; set; }
        public string NoRecibo { get; set; }
        public int TipoPago { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }

        public Egreso(int egreso,DateTime fechaHora,int monto,string recibo,int tipoPago,int usuario,int caja)
        {
            this.egreso = egreso;
            this.FechaHora = fechaHora;
            this.Monto = monto;
            this.NoRecibo = recibo;
            this.TipoPago = tipoPago;
            this.Usuario = usuario;
            this.Caja = caja;
        }
    }
}