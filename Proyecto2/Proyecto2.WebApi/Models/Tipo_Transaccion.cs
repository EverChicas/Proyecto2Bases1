﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Tipo_Transaccion
    {
        public int TipoTransaccion { get; set; }
        public string Nombre { get; set; }

        public Tipo_Transaccion(int TipoTransaccion,string nombre)
        {
            this.TipoTransaccion = TipoTransaccion;
            this.Nombre = nombre;
        }
    }
}