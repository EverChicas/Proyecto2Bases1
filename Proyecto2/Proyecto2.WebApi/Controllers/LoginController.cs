using MySql.Data.MySqlClient;
using Proyecto2.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public Usuario login(int user,string pass)
        {
            Usuario tmp = null;
            using(MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion()))
            {
                conection.Open();
                MySqlCommand command = new MySqlCommand("LOGIN_USUARIO", conection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", user);
                command.Parameters.AddWithValue("@PASS", pass);
                MySqlDataReader reader = command.ExecuteReader();
                
                if(reader.Read())
                {
                    tmp = new Usuario((int)reader["Usuario"],
                        (string)reader["Nombre"],
                        (string)reader["Direccion"],
                        (string)reader["Telefono"],
                        (string)reader["Correo"],
                        (string)reader["Password"],
                        (int)reader["Rol_Usuario"]);
                }   
            }
            return tmp;
        }
    }
}
