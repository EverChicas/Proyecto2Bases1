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
    public class CajaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Caja> Get()
        {
            List<Caja> lista = new List<Caja>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("CAJA_ABRIR", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Caja(
                    int.Parse(reader.GetValue(0).ToString()),
                    double.Parse(reader.GetValue(1).ToString()),
                    int.Parse(reader.GetValue(2).ToString())));
            }
            conection.Close();
            return lista;
        }

        [HttpPost]
        public void AbrirCaja(int usuario, int caja)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("ABRIR_CAJA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAJA", caja);
            command.Parameters.AddWithValue("@USUARIO", usuario);
            double res = command.ExecuteNonQuery();
            conection.Close();
        }

        [HttpPost]
        public Caja BuscarCaja(int caja)
        {
            Caja retornar = null;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("BUSCAR_CAJA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAJA", caja);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                retornar = new Caja(
                    int.Parse(reader.GetValue(0).ToString()),
                    Double.Parse(reader.GetValue(1).ToString()),
                    int.Parse(reader.GetValue(2).ToString()));
            }
            conection.Close();
            return retornar;
        }
    }
}
