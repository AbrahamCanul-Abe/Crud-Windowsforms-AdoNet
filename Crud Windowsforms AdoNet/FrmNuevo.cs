using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Windowsforms_AdoNet
{
    public partial class FrmNuevo : Form
    {
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
            txtCategoria.Text = oProductos.CategoriaId.ToString();
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
                    oProductosDB.Add(txtNombre.Text, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtCategoria.Text));
                }
                else
                {
                    oProductosDB.Update(txtNombre.Text, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtCategoria.Text), (int)Id);
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
    }
}
