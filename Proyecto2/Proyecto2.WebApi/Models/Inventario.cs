using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Inventario
    {
        public int inventario { get; set; }
        public int UnidadesDisponibles { get; set; }
        public int Producto { get; set; }

        public Inventario(int inventario,int unidadesDisponibles,int producto)
        {
            this.inventario = inventario;
            this.UnidadesDisponibles = unidadesDisponibles;
            this.Producto = producto;
        }
    }
}