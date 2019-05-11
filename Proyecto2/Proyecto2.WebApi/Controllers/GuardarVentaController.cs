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
    public class GuardarVentaController : ApiController
    {
        [HttpPost]
        public void guardarVenta(VentaFactura venta)
        {
            string tmp = venta.factura.FechaHora.ToString("yyyy-MM-dd HH:mm:ss");
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("GUARDAR_VENTA", conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NIT", venta.venta.NIT);
            command.Parameters.AddWithValue("@NOMBRE_CLIENTE", venta.venta.NombreCliente);
            command.Parameters.AddWithValue("@IVA", venta.venta.IVA);
            command.Parameters.AddWithValue("@PAGADO", venta.venta.MontoPagado);
            command.Parameters.AddWithValue("@USUARIO", venta.venta.Usuario);
            command.Parameters.AddWithValue("@CAJA", venta.venta.Caja);
            command.Parameters.AddWithValue("@FACTURA", venta.venta.Factura);
            command.Parameters.AddWithValue("@FECHA", tmp);
            command.ExecuteNonQuery();
            conection.Close();
        }
    }
}
