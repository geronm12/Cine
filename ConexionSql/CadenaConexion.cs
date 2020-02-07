using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
 
using System.Data;


namespace Cine.ConexionSql
{
    public class CadenaConexion
    {
      

        public const string Servidor = @"127.0.0.1";
        public const string BaseDeDatos = "Cines";
        public const string Usuario = "root";
        public const string Password = "agente21";

        
        public static string ObtenerCadenaConexionMySqlFirestore => $"Server={Servidor};Database={BaseDeDatos};Uid={Usuario};Pwd={Password};";


    }
}
