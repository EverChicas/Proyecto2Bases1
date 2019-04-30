using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Movimiento
    {
        public int movimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public int SaldoCaja { get; set; }
        public int Usuario { get; set; }
        public int Caja { get; set; }

        public Movimiento(int movimiento,DateTime fechaHora,string descripcion,int monto,int saldoCaja,int usuario,int caja)
        {
            this.movimiento = movimiento;
            this.FechaHora = fechaHora;
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.SaldoCaja = saldoCaja;
            this.Usuario = usuario;
            this.Caja = caja;
        }

    }
}