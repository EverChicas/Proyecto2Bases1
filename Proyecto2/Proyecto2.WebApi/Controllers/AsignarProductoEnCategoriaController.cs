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
    public class AsignarProductoEnCategoriaController : ApiController
    {
        [HttpPost]
        public Boolean asignandoProductoEnCategoria(string nombre, string tipo_categoria)
        {
            Boolean resultado = false;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("AGREGAR_PRODUCTO_EN_CATEGORIA", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_PRODUCTO", nombre);
            command.Parameters.AddWithValue("@NOMBRE_CATEGORIA", tipo_categoria);
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
