using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ControlVentasCore.Utilerias
{
    /// <summary>
    /// Definicion de clase para metodos de SQLClient
    /// </summary>
    public class SQLHelper
    {
        #region Methods
        /// <summary>
        /// Metodo que permite ejecutar comando select y se devuelve en un Datatable
        /// </summary>
        /// <param name="SelectCommand">Comando select</param>
        /// <param name="ConnectionString">Conexion a la bd</param>
        /// <returns>datatable que contiene los datos del select</returns>
        public static DataTable ExecuteDatatable(string SelectCommand, string ConnectionString)
        {
            if (string.IsNullOrEmpty(SelectCommand)) throw new ArgumentNullException("No recibimos el comando select");
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("No recibimos el string de conexion");

            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(SelectCommand, ConnectionString);
                da.Fill(dt);
                Connection.Close();
            }
            return dt;
            
        }
        /// <summary>
        /// Metodo que ejecuta un comando y regresa un resultado de ese comando
        /// </summary>
        /// <param name="Query">Comando a ejecutar</param>
        /// <param name="ConnectionString">Connexion con la bd</param>
        /// <returns>Resultado del comando</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object ExecuteScalar(string Query, string ConnectionString)
        {
            if (string.IsNullOrEmpty(Query)) throw new ArgumentNullException("No recibimos el query a ejecutar");
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("No recibimos el string de conexion");

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                using (SqlCommand Comm = new SqlCommand(Query, Connection))
                    return Comm.ExecuteScalar();
        }

        /// <summary>
        /// Metodo que permite ejecutar un comando y no devuelve nada
        /// </summary>
        /// <param name="Query">Comando a ejecutar</param>
        /// <param name="ConnectionString">Connexion con la bd</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ExecuteNonQuery(string Query, string ConnectionString)
        {
            if (string.IsNullOrEmpty(Query)) throw new ArgumentNullException("No recibimos el query a ejecutar");
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("No recibimos el string de conexion");

            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                using (SqlCommand Comm = new SqlCommand(Query, Connection))
                    Comm.ExecuteNonQuery(); 
        }
        #endregion
    }
}
