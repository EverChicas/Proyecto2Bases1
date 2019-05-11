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
    public class ListadoGeneralClientesController : ApiController
    {
        [HttpPost]
        public IEnumerable<Cliente> ListaDeClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LISTADO_CLIENTES", conection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                lista.Add(new Cliente(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), int.Parse(reader.GetValue(2).ToString()), reader.GetValue(3).ToString(), reader.GetValue(4).ToString()));
            }
            conection.Close();
            return lista;
        }
    }
}
