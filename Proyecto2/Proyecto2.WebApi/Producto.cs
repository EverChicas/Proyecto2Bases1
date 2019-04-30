using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi
{
    public class Producto
    {
        public int producto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public Producto(int producto,string nombre,int precio)
        {
            this.producto = producto;
            this.Nombre = nombre;
            this.Precio = precio;
        }
    }
}