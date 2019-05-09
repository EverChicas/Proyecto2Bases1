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
    public class ProductosSinExistenciaController : ApiController
    {
        [HttpPost]
        public IEnumerable<Producto> listaGeneral()
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("PRODUCTOS_SIN_EXISTENCIA", conection);
            command.CommandType = CommandType.StoredProcedure;
            List<Producto> lista = new List<Producto>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Producto(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), double.Parse(reader.GetValue(2).ToString())));
            }
            conection.Close();
            return lista;
        }
    }
}
