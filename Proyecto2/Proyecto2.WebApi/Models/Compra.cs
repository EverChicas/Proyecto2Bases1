using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Compra
    {
        public int compra { get; set; }
        public DateTime Fecha { get; set; }
        public int PrecioUnidad { get; set; }
        public int ValorCompra { get; set; }
        public int Cantidad { get; set; }
        public int NoFactura { get; set; }
        public int Producto { get; set; }
        public int Proveedor { get; set; }
        public int Usuario { get; set; }

        public Compra(int compra,DateTime fecha,int precio,int valor,int cantidad,int noFactura,int producto,int proveedor,int usuario)
        {
            this.compra = compra;
            this.Fecha = fecha;
            this.PrecioUnidad = precio;
            this.ValorCompra = valor;
            this.Cantidad = cantidad;
            this.NoFactura = noFactura;
            this.Producto = producto;
            this.Proveedor = proveedor;
            this.Usuario = usuario;
        }

    }
}