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
    public class MovimientosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Movimiento> Get()
        {
            List<Movimiento> lista = new List<Movimiento>();

            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LISTA_MOVIMIENTOS", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Movimiento(
                    int.Parse(reader.GetValue(0).ToString()),
                    DateTime.Parse(reader.GetValue(1).ToString()),
                    reader.GetValue(2).ToString(),
                    double.Parse(reader.GetValue(3).ToString()),
                    double.Parse(reader.GetValue(4).ToString()),
                    int.Parse(reader.GetValue(5).ToString()),
                    int.Parse(reader.GetValue(6).ToString())));
            }
            conection.Close();
            return lista;
        }

        [HttpPost]
        public IEnumerable<Movimiento> MovimientosFecha(string fecha)
        {
            List<Movimiento> lista = new List<Movimiento>();

            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("MOVIMIENTO_FECHA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FECHA", fecha);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Movimiento(
                    int.Parse(reader.GetValue(0).ToString()),
                    DateTime.Parse(reader.GetValue(1).ToString()),
                    reader.GetValue(2).ToString(),
                    double.Parse(reader.GetValue(3).ToString()),
                    double.Parse(reader.GetValue(4).ToString()),
                    int.Parse(reader.GetValue(5).ToString()),
                    int.Parse(reader.GetValue(6).ToString())));
            }
            conection.Close();
            return lista;
        }

    }
}
