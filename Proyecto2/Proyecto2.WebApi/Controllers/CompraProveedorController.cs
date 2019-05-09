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
    public class CompraProveedorController : ApiController
    {
        [HttpPost]
        public Boolean registrarCompra(string precioUnitario, string valorCompra, int cantidad, int noFactura, int proveedor, int usuario, int producto)
        {
            double precioU = Double.Parse(precioUnitario);
            double valorC = Double.Parse(valorCompra);
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("AGREGAR_COMPRA", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PRECIO_UNITARIO_P", precioU);
            command.Parameters.AddWithValue("@VALOR_COMPRA_P", valorC);
            command.Parameters.AddWithValue("@CANTIDAD", cantidad);
            command.Parameters.AddWithValue("@NO_FACTURA_P", noFactura);
            command.Parameters.AddWithValue("@PROVEEDOR_P", proveedor);
            command.Parameters.AddWithValue("@USUARIO_P", usuario);
            command.Parameters.AddWithValue("@PRODUCTO_P", producto);
            MySqlDataReader reader = command.ExecuteReader();
            Boolean resultado = false;
            while (reader.Read())
            {
                if (int.Parse(reader.GetValue(0).ToString()) == 1)
                    resultado = true;
            }
            conection.Close();
            return resultado;
        }
    }
}