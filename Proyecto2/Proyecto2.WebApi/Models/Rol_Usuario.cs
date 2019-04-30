namespace Proyecto2.WebApi.Models
{
    using System;

    public partial class Rol_Usuario
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