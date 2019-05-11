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
    public class NuevoClienteController : ApiController
    {
        [HttpPost]
        public Boolean creandoNuevoCliente(int dpi, string nombre, int nit, string telefono, string correo)
        {
            Boolean resultado = false;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("CREAR_CLIENTE", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DPI_P", dpi);
            command.Parameters.AddWithValue("@NOMBRE_CLIENTE_P", nombre);
            command.Parameters.AddWithValue("@NIT_P", nit);
            command.Parameters.AddWithValue("@TELEFONO_P", telefono);
            command.Parameters.AddWithValue("@CORREO_P", correo);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (int.Parse(reader.GetValue(0).ToString()) == 1)
                    resultado = true;
            }
            conection.Close();
            return resultado;
        }
    }
}
