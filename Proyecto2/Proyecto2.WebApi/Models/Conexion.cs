using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.WebApi.Models
{
    public class Conexion
    {
        public static string CadenaConexion()
        {
            MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder();
            conn.Server = "localhost";
            conn.Database = "proyecto2bases1";
            conn.UserID = "root";
            conn.Password = "chicas";
            conn.IntegratedSecurity = false;
            return conn.ToString();
        }
    }
}