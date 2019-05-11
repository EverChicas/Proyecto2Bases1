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
    public class MayorVentaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Venta> Get()
        {
            List<Venta> lista = new List<Venta>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("MAYOR_VENTA_DIA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Venta(
                    int.Parse(reader.GetValue(0).ToString()),
                    int.Parse(reader.GetValue(1).ToString()),
                    reader.GetValue(2).ToString(),
                    double.Parse(reader.GetValue(3).ToString()),
                    double.Parse(reader.GetValue(4).ToString()),
                    int.Parse(reader.GetValue(5).ToString()),
                    int.Parse(reader.GetValue(6).ToString()),
                    int.Parse(reader.GetValue(7).ToString())));
            }
            conection.Close();
            return lista;
        }
    }
}
