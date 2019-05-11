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
    public class NuevosDetallesFacturaController : ApiController
    {
        [HttpPost]
        public void detallesFactura(List<Detalle> detalles)
        {
            foreach(Detalle item in detalles)
            {
                MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
                conection.Open();
                MySqlCommand command = new MySqlCommand("NUEVO_DETALLE_FACTURA", conection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FACTURA",item.Factura);
                command.Parameters.AddWithValue("@CLIENTE", item.Cliente);
                command.Parameters.AddWithValue("@PRECIO", item.PrecioUnidad);
                command.Parameters.AddWithValue("@CANTIDAD", item.Cantidad);
                command.Parameters.AddWithValue("@PRODUCTO", item.Producto);
                command.ExecuteNonQuery();
                conection.Close();
            }
        }
    }
}
