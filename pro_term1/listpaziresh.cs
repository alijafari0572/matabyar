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
    public partial class listpaziresh : Form
    {
        public listpaziresh()
        {
            InitializeComponent();
        }
        pazireshbimar_BLL PB = new pazireshbimar_BLL();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            //MessageBox.Show(bPersianCalenderTextBox1.Text);

            dataGridViewX1.DataSource = PB.ReadSQL(bPersianCalenderTextBox1.Text);
        }

        private void listpaziresh_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource =null;
            dataGridViewX1.DataSource = PB.ReadSQL();
        }

        private void bPersianCalenderTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
