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
    public class NuevoClienteController : ApiController
    {
        [HttpPost]
        public void agregarCliente(Cliente nuevo)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("NUEVO_CLIENTE", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DPI",nuevo.DPI);
            command.Parameters.AddWithValue("@NOMBRE", nuevo.Nombre);
            command.Parameters.AddWithValue("@NIT", nuevo.NIT);
            command.Parameters.AddWithValue("@TELEFONO", nuevo.Telefono);
            command.Parameters.AddWithValue("@CORREO", nuevo.Correo);
            command.ExecuteNonQuery();
            conection.Close();
        }

    }
}
