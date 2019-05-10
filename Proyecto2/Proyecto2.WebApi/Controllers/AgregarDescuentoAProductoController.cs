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
    public class AgregarDescuentoAProductoController : ApiController
    {
        [HttpPost]
        public Boolean agregandoDescuento(string nombre, string fecha_ini, string fecha_fin, int porcentaje)
        {
            Boolean resultado = false;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("AGREGAR_DESCUENTO_A_PRODUCTO", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_PRODUCTO", nombre);
            command.Parameters.AddWithValue("@FECHA_I", fecha_ini);
            command.Parameters.AddWithValue("@FECHA_F", fecha_fin);
            command.Parameters.AddWithValue("@PORCENTAJE", porcentaje);
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
