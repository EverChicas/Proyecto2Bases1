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
    public class NuevaFacturaController : ApiController
    {
        [HttpPost]
        public Factura nuevaFactura(Factura factura)
        {
            string tmp = factura.FechaHora.ToString("yyyy-MM-dd HH:mm:ss");
            Factura retornar = new Factura(0,System.DateTime.Now,0,0,0,0);

            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("NUEVA_FACTURA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FECHA", tmp);
            command.Parameters.AddWithValue("@CLIENTE", factura.Cliente);
            command.Parameters.AddWithValue("@NIT", factura.NIT);
            command.Parameters.AddWithValue("@TOTAL", factura.Total);
            command.Parameters.AddWithValue("@IVA", factura.IVA_Venta);
            command.ExecuteNonQuery();
            conection.Close();

            
            conection.Open();
            MySqlCommand command2 = new MySqlCommand("RETORNAR_FACTURA", conection);
            command2.CommandType = System.Data.CommandType.StoredProcedure;
            command2.Parameters.AddWithValue("@FECHA", tmp);
            MySqlDataReader reader = command2.ExecuteReader();
            
            while (reader.Read())
            {
                retornar.factura = int.Parse(reader.GetValue(0).ToString());
                retornar.FechaHora = DateTime.Parse(reader.GetValue(1).ToString());
                retornar.Cliente = int.Parse(reader.GetValue(2).ToString());
                retornar.NIT = int.Parse(reader.GetValue(2).ToString());
                retornar.Total = double.Parse(reader.GetValue(2).ToString());
                retornar.IVA_Venta = double.Parse(reader.GetValue(2).ToString());
            }
            conection.Close();
            return retornar;
        }
    }
}
