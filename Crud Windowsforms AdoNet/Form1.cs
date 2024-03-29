﻿using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNuevo frm = new FrmNuevo();
            frm.ShowDialog();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                FrmNuevo frmEdit = new FrmNuevo(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();

            try
            {
                if (Id != null)
                {
                    ProductosDB oProductosDB = new ProductosDB();
                    oProductosDB.Delete((int)Id);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar "+ex.Message);
            }
            
        }

        #region helper
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
            
        }
        #endregion
    }
}
