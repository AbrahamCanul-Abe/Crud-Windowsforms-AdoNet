using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Windowsforms_AdoNet
{
    public partial class FrmNuevo : Form
    {
        private string connectionString
            = "Data Source=LENO\\SQLEXPRESS2;Initial Catalog=ControlVentas;" +
            "User=sa;Password=developer";
        private int? Id;
        public FrmNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            ProductosDB oProductosDB = new ProductosDB();
            Productos oProductos = oProductosDB.Get((int)Id);
            txtNombre.Text = oProductos.Nombre;
            txtDescripcion.Text = oProductos.Descripcion;
            txtPrecio.Text = oProductos.Precio.ToString();
            //txtCategoria.Text = oProductos.CategoriaId.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductosDB oProductosDB = new ProductosDB();
            try
            {
                if(Id == null)
                {
                    int indice = cbxCategorias.SelectedIndex;
                    oProductosDB.Add(txtNombre.Text, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), (int)(cbxCategorias.SelectedIndex));
                }
                else
                {
                    oProductosDB.Update(txtNombre.Text, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), (int)(cbxCategorias.SelectedIndex), (int)Id);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("select nombre from categorias", connection);
                connection.Open();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cbxCategorias.Items.Add(registro["Nombre"].ToString());
                }
                connection.Close();
            }
        }
    }
}
