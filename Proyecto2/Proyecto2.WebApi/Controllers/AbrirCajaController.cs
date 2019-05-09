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
    public class AbrirCajaController : ApiController
    {
        [HttpPost]
        public void AbrirCaja(int usuario, int caja)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("ABRIR_CAJA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAJA", caja);
            command.Parameters.AddWithValue("@USUARIO", usuario);
            int res = command.ExecuteNonQuery();
            conection.Close();
        }
    }
}
