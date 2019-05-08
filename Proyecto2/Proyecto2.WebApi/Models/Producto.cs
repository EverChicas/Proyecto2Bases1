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

        public int unidades_disponibles { get; set; }
        
        public Producto(int producto, string nombre, double precio)
        {
            this.producto = producto;
            this.Nombre = nombre;
            this.Precio = precio;
        }

        public Producto(int producto, string nombre, double precio, int unidades_disponibles)
        {
            this.producto = producto;
            this.Nombre = nombre;
            this.Precio = precio;
            this.unidades_disponibles = unidades_disponibles;
        }
    }
}