using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Categoria
    {
        public int Producto { get; set; }
        public int TipoCategoria { get; set; }

        public Categoria(int producto,int tipoCategoria)
        {
            this.Producto = producto;
            this.TipoCategoria = tipoCategoria;
        }
    }
}