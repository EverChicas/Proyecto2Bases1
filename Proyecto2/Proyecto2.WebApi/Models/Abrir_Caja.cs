using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Abrir_Caja
    {
        public DateTime FechaHora { get; set; }
        public double Monto { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }

        public Abrir_Caja(DateTime fechaHora,double monto,int usuario,int caja)
        {
            this.FechaHora = fechaHora;
            this.Monto = monto;
            this.Usuario = usuario;
            this.Caja = caja;
        }
    }
}