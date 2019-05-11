using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.ClienteWeb.Models
{
    public class DetalleCompra
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }
}