using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Tipo_Categoria
    {
        public int TipoCategoria { get; set; }
        public string Nombre { get; set; }

        public Tipo_Categoria(int tipoCategoria,string nombre)
        {
            this.TipoCategoria = tipoCategoria;
            this.Nombre = nombre;
        }
    }
}