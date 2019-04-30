using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int Rol_Usuario { get; set; }

        public Usuario(int usuario,string nombre,string direccion,string telefono,string correo,string password,int RolUsuario)
        {
            this.Id_Usuario = usuario;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Password = password;
            this.Rol_Usuario = RolUsuario;
        }

    }
}