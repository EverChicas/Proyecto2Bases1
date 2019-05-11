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
    public class ProductosConDescuentoController : ApiController
    {
        [HttpPost]
        public IEnumerable<Descuento> ListaDeProductosConDescuento()
        {
            List<Descuento> lista = new List<Descuento>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("LISTADO_PRODUCTOS_CON_DESCUENTO", conection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            Descuento d;
            while (reader.Read())
            {//AGREGANDO = ID, FECHA_INICIO, FECHA_FIN, PORCENTAJE, NOMBRE_PRODUCTO
                lista.Add(new Descuento(int.Parse(reader.GetValue(0).ToString()), DateTime.Parse(reader.GetValue(1).ToString()), DateTime.Parse(reader.GetValue(2).ToString()), int.Parse(reader.GetValue(3).ToString()), reader.GetValue(4).ToString()));              
            }
            conection.Close();
            return lista;
        }
    }
}
