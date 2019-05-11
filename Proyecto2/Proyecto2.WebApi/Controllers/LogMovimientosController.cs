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
    public class LogMovimientosController : ApiController
    {
        // GET: LogMovimientos
        [HttpGet]
        public IEnumerable<Log> LogGeneral()
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LOG_GENERAL", conection);
            command.CommandType = CommandType.StoredProcedure;
            List<Log> lista = new List<Log>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Log(int.Parse(reader.GetValue(0).ToString()), DateTime.Parse(reader.GetValue(1).ToString()), reader.GetValue(2).ToString(), Double.Parse(reader.GetValue(3).ToString()), int.Parse(reader.GetValue(4).ToString()), int.Parse(reader.GetValue(5).ToString())));
            }
            conection.Close();
            return lista;
        }
        [HttpGet]
        public IEnumerable<Log> LogMensual(int mes, int anio)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LOG_MENSUAL", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MES", mes);
            command.Parameters.AddWithValue("@ANIO", anio);
            MySqlDataReader reader = command.ExecuteReader();
            List<Log> lista = new List<Log>();
            while (reader.Read())
            {
                lista.Add(new Log(int.Parse(reader.GetValue(0).ToString()), DateTime.Parse(reader.GetValue(1).ToString()), reader.GetValue(2).ToString(), Double.Parse(reader.GetValue(3).ToString()), int.Parse(reader.GetValue(4).ToString()), int.Parse(reader.GetValue(5).ToString())));
            }
            conection.Close();
            return lista;
        }

        [HttpGet]
        public IEnumerable<Log> LogPorFecha(DateTime fecha)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LOG_POR_FECHA", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FECHA", fecha);
            MySqlDataReader reader = command.ExecuteReader();
            List<Log> lista = new List<Log>();
            while (reader.Read())
            {
                lista.Add(new Log(int.Parse(reader.GetValue(0).ToString()), Convert.ToDateTime(reader.GetValue(1).ToString()), reader.GetValue(2).ToString(), Convert.ToDouble(reader.GetValue(3).ToString()), int.Parse(reader.GetValue(4).ToString()), int.Parse(reader.GetValue(5).ToString())));
            }
            conection.Close();
            return lista;
        }



    }
}