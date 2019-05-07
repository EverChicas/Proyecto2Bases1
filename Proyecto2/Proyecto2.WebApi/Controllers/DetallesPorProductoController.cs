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
    public class DetallesPorProductoController : ApiController
    {
        [HttpPost]
        public IEnumerable<Producto> detalles_PorProductos_(string nombre)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("DETALLES_POR_PRODUCTO", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_PRODUCTO", nombre);
            MySqlDataReader reader = command.ExecuteReader();
            List<Producto> lista = new List<Producto>();
            while(reader.Read())
            {
                lista.Add(new Producto(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), double.Parse(reader.GetValue(2).ToString()), int.Parse(reader.GetValue(3).ToString())));
            }
            conection.Close();
            return lista;
        }
    }
}
