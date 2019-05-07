using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Cerrar_Caja
    {
        public DateTime FechaHora { get; set; }
        public double MontoNumero { get; set; }
        public string MontoLetras { get; set; }
        public string Observacion { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }

        public Cerrar_Caja(DateTime FechaHora,double montoNumero,string montonString,string observacion,int usuario,int caja)
        {
            this.FechaHora = FechaHora;
            this.MontoNumero = montoNumero;
            this.MontoLetras = montonString;
            this.Observacion = observacion;
            this.Usuario = usuario;
            this.Caja = caja;
        }
    }
}