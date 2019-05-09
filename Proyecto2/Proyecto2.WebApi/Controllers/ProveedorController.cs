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
    public class ProveedorController : ApiController
    {
        [HttpGet]
        public IEnumerable<Proveedor> listaProveedores()
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("PROVEEDORES", conection);
            command.CommandType = CommandType.StoredProcedure;
            List<Proveedor> lista = new List<Proveedor>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Proveedor(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString()));
            }
            conection.Close();
            return lista;
        }
        public IEnumerable<Proveedor> getProveedor(int proveedor)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("GET_PROVEEDOR", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PROVEEDOR_P", proveedor);
            MySqlDataReader reader = command.ExecuteReader();
            List<Proveedor> lista = new List<Proveedor>();
            while (reader.Read())
            {
                lista.Add(new Proveedor(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString()));
            }
            conection.Close();
            return lista;
        }



        [HttpPost]
        public Boolean registrarProveedor(string nombre, string direccion, string correo, string telefono)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("AGREGAR_PROVEEDOR", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_P", nombre);
            command.Parameters.AddWithValue("@DIRECCION_P", direccion);
            command.Parameters.AddWithValue("@CORREO_P", correo);
            command.Parameters.AddWithValue("@TELEFONO_P", telefono);
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
        [HttpPost]
        public Boolean eliminarProveedor(int proveedor)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("ELIMINAR_PROVEEDOR", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PROVEEDOR_P", proveedor);
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


        [HttpPost]
        public Boolean modificarProveedor(int proveedor,string nombre, string direccion, string correo, int telefono)
        {
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("MODIFICAR_PROVEEDOR", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PROVEEDOR_P", proveedor);
            command.Parameters.AddWithValue("@NOMBRE_P", nombre);
            command.Parameters.AddWithValue("@DIRECCION_P", direccion);
            command.Parameters.AddWithValue("@CORREO_P", correo);
            command.Parameters.AddWithValue("@TELEFONO_P", telefono);
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