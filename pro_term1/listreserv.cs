using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace pro_term1
{
    public partial class listreserv : Form
    {
        public listreserv()
        {
            InitializeComponent();
        }
        reservbimar_BLL RB = new reservbimar_BLL();
        private void listreserv_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = RB.ReadSQL();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            //MessageBox.Show(bPersianCalenderTextBox1.Text);

            dataGridViewX1.DataSource = RB.ReadSQL(bPersianCalenderTextBox1.Text);
        }
        private void bPersianCalenderTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            //MessageBox.Show(bPersianCalenderTextBox1.Text);

            dataGridViewX1.DataSource = RB.ReadSQL(bPersianCalenderTextBox1.Text);
        }
    }
}
