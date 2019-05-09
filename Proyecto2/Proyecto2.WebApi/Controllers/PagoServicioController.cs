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
    public class PagoServicioController : ApiController
    {
        [HttpPost]
        public void PagarServicio(Egreso egreso)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("INGRESAR_EGRESO", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MONTO",egreso.Monto);
            command.Parameters.AddWithValue("@NO_RECIBO",egreso.NoRecibo);
            command.Parameters.AddWithValue("@TIPO_PAGO",egreso.TipoPago);
            command.Parameters.AddWithValue("@USUARIO",egreso.Usuario);
            command.Parameters.AddWithValue("@CAJA",egreso.Caja);
            command.ExecuteNonQuery();
            conection.Close();
        }
    }
}
