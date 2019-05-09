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
    public class NuevoProductoController : ApiController
    {
        [HttpPost]
        public Boolean creandoNuevoProducto(string nombre, double precio, int unidades_disponibles)
        {
            Boolean resultado = false;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("CREAR_PRODUCTO", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_PRODUCTO", nombre);
            command.Parameters.AddWithValue("@PRECIO_PRODUCTO", precio);
            command.Parameters.AddWithValue("@U_DISPONIBLES", unidades_disponibles);
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
