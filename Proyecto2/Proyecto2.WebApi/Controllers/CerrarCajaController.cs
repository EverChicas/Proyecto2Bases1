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
    public class CerrarCajaController : ApiController
    {
        [HttpPost]
        public void CerrarCaja(Cerrar_Caja caja)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("CERRAR_CAJA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CAJA", caja.Caja);
            command.Parameters.AddWithValue("@MONTO_NUMERO", caja.MontoNumero);
            command.Parameters.AddWithValue("@MONTO_LETRA", caja.MontoLetras);
            command.Parameters.AddWithValue("@OBSERVACIONES", caja.Observacion);
            command.Parameters.AddWithValue("@USUARIO", caja.Usuario);
            command.ExecuteNonQuery();
            conection.Close();
        }
    }
}
