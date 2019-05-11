using MySql.Data.MySqlClient;
using Proyecto2.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2.WebApi.Controllers
{
    public class ClientesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Cliente> listaProductos()
        {
            List<Cliente> lista = new List<Cliente>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("CLIENTES", conection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Cliente(
                    int.Parse(reader.GetValue(0).ToString()), 
                    reader.GetValue(1).ToString(), 
                    int.Parse(reader.GetValue(2).ToString()),
                    reader.GetValue(3).ToString(),
                    reader.GetValue(4).ToString()
                    ));
            }
            conection.Close();
            return lista;
        }
    }
}
