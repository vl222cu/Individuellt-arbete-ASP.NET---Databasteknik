using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt_1dv406.Model.DAL
{
    public abstract class DALBase
    {
        // Fält
        private static string _connectionString;

        // Skapar och returnerar en referens till ett
        // anslutningsobjekt
        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Kontruktor
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["WP13_vl222cu_ProjectConnectingString"].ConnectionString;
        }
    }
}