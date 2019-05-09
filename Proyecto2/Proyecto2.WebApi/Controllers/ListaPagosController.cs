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
    public class ListaPagosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Tipo_Pago> Get()
        {
            List<Tipo_Pago> lista = new List<Tipo_Pago>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LISTA_PAGOS", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Tipo_Pago(
                    int.Parse(reader.GetValue(0).ToString()),
                    reader.GetValue(1).ToString()));
            }
            conection.Close();
            return lista;
        }
    }
}
