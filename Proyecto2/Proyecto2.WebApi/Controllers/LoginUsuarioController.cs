using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Proyecto2.WebApi.Models;

namespace Proyecto2.WebApi.Controllers
{
    public class LoginUsuarioController : ApiController
    {
        [HttpPost]
        public Usuario USUARIO_LOGIN(int user, string password)
        {
            Usuario tmp = new Usuario(0, "", "", "", "", "", 0);
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LOGIN_USUARIO", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@USER", user);
            command.Parameters.AddWithValue("@PASS", password);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                tmp.Id_Usuario = int.Parse(reader.GetValue(0).ToString());
                tmp.Nombre = reader.GetValue(1).ToString();
                tmp.Direccion = reader.GetValue(2).ToString();
                tmp.Telefono = reader.GetValue(3).ToString();
                tmp.Correo = reader.GetValue(4).ToString();
                tmp.Password = reader.GetValue(5).ToString();
                tmp.Rol_Usuario = int.Parse(reader.GetValue(6).ToString());
            }
            conection.Close();
            return tmp;
        }
    }
}
