﻿using System;
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
    public class EliminarTipoCategoriaController : ApiController
    {
        [HttpPost]
        public Boolean eliminandoTipoCategoria(string tipo_categoria)
        {
            Boolean resultado = false;
            MySqlConnection conection = new MySqlConnection(Conexion.CadenaConexion());
            conection.Open();
            MySqlCommand command = new MySqlCommand("ELIMINAR_TIPO_CATEGORIA", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_CATEGORIA", tipo_categoria);
            if (command.ExecuteNonQuery() != 0)
                resultado = true;
            conection.Close();
            return resultado;
        }
    }
}
