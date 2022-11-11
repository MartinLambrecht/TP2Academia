using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //Clave por defecto a utlizar para la cadena de conexion
        private const string consKeyDefaultCnnString = "ConnStringExpress";

        private SqlConnection _sqlConn;

        public SqlConnection sqlConn
        { get { return _sqlConn; } set { _sqlConn = value; } }

        protected void OpenConnection()
        {
            string connStrig = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connStrig);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}