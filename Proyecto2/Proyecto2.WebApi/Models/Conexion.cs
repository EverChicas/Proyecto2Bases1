using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Conexion
    {
        /// <summary>
        /// Clase que retorna la cadena de conexion a la base de datos
        /// </summary>
        /// <returns></returns>
        public static string CadenaConexion()
        {
            MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder();

            
            conn.Server = "localhost";
            conn.Database = "proyecto2bases1";
            conn.UserID = "root";
            conn.Password = "chicas";
            
            /*
            conn.Server = "proyecto2bases1.curgdovy7biz.us-east-2.rds.amazonaws.com";
            conn.Database = "Proyecto2Bases1";
            conn.UserID = "proyecto2bases1";
            conn.Password = "proyecto2bases1";
            conn.IntegratedSecurity = false;
            */        
            return conn.ToString();
        }
    }
}