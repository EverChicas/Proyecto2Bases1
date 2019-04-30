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
    public class Rol_UsuarioController : ApiController
    {
        [HttpGet]
        public IEnumerable<Rol_Usuario> Get()
        {
            List<Rol_Usuario> lista = new List<Rol_Usuario>();
            
            using(MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion()))
            {
                MySqlDataAdapter msda = new MySqlDataAdapter("SELECT * FROM Rol_Usuario", conection);
                DataTable dt = new DataTable();
                msda.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    lista.Add(new Rol_Usuario(Convert.ToInt32(row["Rol_Usuario"]), row["Nombre"].ToString()));
                }
            }

            return lista;
        }

        [HttpPost]
        public void InsertarRolUsuario(string rol)
        {
            using(MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion()))
            {
                conection.Open();
                MySqlCommand command = new MySqlCommand("AGREGAR_ROL_USUARIO", conection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NOMBRE",rol);
                int res = command.ExecuteNonQuery();
                conection.Close();
            }
        }

    }
}



