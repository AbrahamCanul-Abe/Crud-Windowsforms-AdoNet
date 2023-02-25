using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Crud_Windowsforms_AdoNet
{
    public class ProductosDB
    {
        private string connectionString 
            = "Data Source=LENO\\SQLEXPRESS2;Initial Catalog=ControlVentas;" +
            "User=sa;Password=developer";

        public bool Ok()
        {
            try {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch {
                return false;
            }
            return true;
        }

        public List<Productos> Get() {
            List<Productos> productos = new List<Productos>();

            string query = "select Id, Nombre, Descripcion, Precio, CategoriaId from productos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Productos oProductos = new Productos();
                        oProductos.Id = reader.GetInt32(0);
                        oProductos.Nombre = reader.GetString(1);
                        oProductos.Descripcion = reader.GetString(2);
                        oProductos.Precio = reader.GetDecimal(3);
                        oProductos.CategoriaId = reader.GetInt32(4);

                        productos.Add(oProductos);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }
            }

                return productos;
        }
    }

    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
    }
}
