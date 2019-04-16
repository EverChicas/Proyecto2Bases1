using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Rol_Usuario
    {
        public int RolUsuario { get; set; }
        public string Nombre { get; set; }

        public Rol_Usuario(int id_rol,String nombre)
        {
            this.RolUsuario = id_rol;
            this.Nombre = nombre;
        }
    }
}