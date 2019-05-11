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
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("NUEVA_FACTURA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLIENTE", factura.Cliente);
            command.Parameters.AddWithValue("@NIT", factura.NIT);
            command.Parameters.AddWithValue("@TOTAL", factura.Total);
            command.Parameters.AddWithValue("@IVA", factura.IVA_Venta);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                factura = new Factura(
                    int.Parse(reader.GetValue(0).ToString()),
                    DateTime.Parse(reader.GetValue(1).ToString()),
                    int.Parse(reader.GetValue(2).ToString()),
                    int.Parse(reader.GetValue(2).ToString()),
                    double.Parse(reader.GetValue(2).ToString()),
                    double.Parse(reader.GetValue(2).ToString())
                    );
            }
            conection.Close();
            return factura;
        }
    }
}
