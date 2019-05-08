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
    public class ProveedorController : ApiController
    {
        [HttpPost]
        public Boolean registrarProveedor(string nombre, string direccion, string correo, string telefono)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("AGREGAR_PROVEEDOR", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_P", nombre);
            command.Parameters.AddWithValue("@DIRECCION_P", direccion);
            command.Parameters.AddWithValue("@CORREO_P", correo);
            command.Parameters.AddWithValue("@TELEFONO_P", telefono);
            MySqlDataReader reader = command.ExecuteReader();
            Boolean resultado = false;
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