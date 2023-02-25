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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Refresh()
        {
            ProductosDB oProductosDB = new ProductosDB();
            dataGridView1.DataSource = oProductosDB.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
