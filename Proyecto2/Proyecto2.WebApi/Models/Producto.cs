using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Producto
    {
        public int producto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(int producto, string nombre, double precio)
        {
            this.producto = producto;
            this.Nombre = nombre;
            this.Precio = precio;
        }
    }
}