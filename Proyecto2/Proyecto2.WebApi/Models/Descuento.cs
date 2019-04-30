using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Descuento
    {
        public int descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int PorcentajeDescuento { get; set; }
        public int Producto { get; set; }

        public Descuento(int descuento,DateTime fechaInicio,DateTime fechaFin,int porcentaje,int producto)
        {
            this.descuento = descuento;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.PorcentajeDescuento = porcentaje;
            this.Producto = producto;
        }
    }
}