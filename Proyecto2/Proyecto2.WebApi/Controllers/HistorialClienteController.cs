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
    public class HistorialClienteController : ApiController
    {
        [HttpPost]
        public IEnumerable<Factura> BuscarCaja(int cliente)
        {
            List<Factura> lista = new List<Factura>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("HISTORIAL_CLIENTE", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLIENTE", cliente);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Factura(
                    int.Parse(reader.GetValue(0).ToString()),
                    DateTime.Parse(reader.GetValue(1).ToString()),
                    int.Parse(reader.GetValue(2).ToString()),
                    int.Parse(reader.GetValue(3).ToString()),
                    double.Parse(reader.GetValue(4).ToString()),
                    double.Parse(reader.GetValue(5).ToString())));
            }
            return lista;
        }
    }
}
