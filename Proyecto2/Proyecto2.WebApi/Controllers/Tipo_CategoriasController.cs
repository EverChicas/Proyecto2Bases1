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
    public class Tipo_CategoriasController : ApiController
    {
        [HttpGet]
        public IEnumerable<Tipo_Categoria> listaTipo_categorias()
        {
            List<Tipo_Categoria> lista = new List<Tipo_Categoria>();
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("TIPO_CATEGORIAS", conection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Tipo_Categoria(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString()));
            }
            conection.Close();
            return lista;
        }
    }
}
