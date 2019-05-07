using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Detalle
    {
        public int Factura { get; set; }
        public int Producto { get; set; }
        public int Cliente { get; set; }
        public double PrecioUnidad { get; set; }
        public int Cantidad { get; set; }

        public Detalle(int factura,int producto,int cliente,double precio_unidad,int cantidad)
        {
            this.Factura = factura;
            this.Producto = producto;
            this.Cliente = cliente;
            this.PrecioUnidad = precio_unidad;
            this.Cantidad = cantidad;
        }
    }
}