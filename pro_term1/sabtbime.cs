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
    public partial class sabtbime : Form
    {
        public sabtbime()
        {
            InitializeComponent();
        }
        //public Form form = new Form();
        bime_BLL bibll = new bime_BLL();
        public int idbi;
        public bool flag;//tru== create,false==edit
        public void RefreshGrid()//refresh datagridview
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bibll.ReadSQL(); //Works great
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
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            flag = true;
            moshakhsat_bime form = new moshakhsat_bime();
            form.flag = true;
            form.ShowDialog(); // or form.ShowDialog(this);
        }

        private void sabtbime_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bibll.ReadSQL();
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
        private void buttonItem2_Click(object sender, EventArgs e)//ویرایش
        {
            if (idbi > 0)
            {
                flag = false;
                moshakhsat_bime form = new moshakhsat_bime();
                form.flag = false;
                form.idbi = idbi;
                form.ShowDialog(); // or form.ShowDialog(this);

            }
            else
            {
                MessageBox.Show("لطفا یک ردیف انتخاب کنید");
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)//حذف
        {
            if (idbi > 0)
            {
                MessageBox.Show(bibll.Delet(idbi));
                dataGridViewX1.DataSource = bibll.ReadSQL();
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

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idbi = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value);

        }
    }
}
