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
    public partial class sabtbimar : Form
    {
        public sabtbimar()
        {
            InitializeComponent();
        }
        //public Form form = new Form();
        bimar_BLL bll = new bimar_BLL();
        public int id;
        public bool flag;//tru== create,false==edit
        public void RefreshGrid()//refresh datagridview
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.ReadSQL(); //Works great
            foreach (DataGridViewColumn i in dataGridViewX1.Columns)
            {
                switch (i.Name)
                {
                    case "id":
                        i.Visible = false;
                        break;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)//ایجاد بیمار جدید
        {
            flag = true;
            moshakhsat_bimar form = new moshakhsat_bimar();
            form.flag = true;
            form.ShowDialog(); // or form.ShowDialog(this);
            
            
        }

        private void sabtbimar_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.ReadSQL();
            foreach (DataGridViewColumn i in dataGridViewX1.Columns)//پنهان کردن ستون ایدی
            {
                switch (i.Name)
                {
                    case "id":
                        i.Visible = false;
                        break;
                }
            }
            // MessageBox.Show(Convert.ToString( bll.Number()));
        }

        

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value);
        }

        private void buttonItem2_Click(object sender, EventArgs e)//ویرایش
        {
            if (id>0)
            {
                flag = false;
                moshakhsat_bimar form = new moshakhsat_bimar();
                form.flag = false;
                form.id = id;
                form.ShowDialog(); // or form.ShowDialog(this);
               
            }
            else
            {
                MessageBox.Show("لطفا یک ردیف انتخاب کنید");
            }
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)//حذف
        {
            if (id > 0)
            {
                MessageBox.Show(bll.Delet(id));
                dataGridViewX1.DataSource = bll.ReadSQL();
                foreach (DataGridViewColumn i in dataGridViewX1.Columns)//پنهان کردن ستون ایدی
                {
                    switch (i.Name)
                    {
                        case "id":
                            i.Visible = false;
                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("لطفا یک ردیف انتخاب کنید");
            }
        }

        private void dataGridViewX1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value);
            //دادن ایدی به صفحه های مختلف
           paziresh.id = id;
           Reservtime.id = id;
           Tazrighat.id = id;
          
           this.Close();

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
