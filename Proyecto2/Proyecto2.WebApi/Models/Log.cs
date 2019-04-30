using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Log
    {
        public int log { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public int MontoMovimiento { get; set; }
        public int Movimiento { get; set; }
        public int Usuario { get; set; }

        public Log(int log,DateTime fechaHora,string descripcion,int montoMovimeinto,int movimiento, int usuario)
        {
            this.log = log;
            this.FechaHora = fechaHora;
            this.Descripcion = descripcion;
            this.MontoMovimiento = montoMovimeinto;
            this.Movimiento = movimiento;
            this.Usuario = usuario;
        }

    }
}