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
    public partial class sabtpezeshk : Form
    {
        public sabtpezeshk()
        {
            InitializeComponent();
        }
        //public Form form = new Form();
        pezeshk_BLL bll = new pezeshk_BLL();
        public int idP;
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

        private void buttonItem1_Click(object sender, EventArgs e)//create
        {
            flag = true;
            moshakhsat_pezeshk form = new moshakhsat_pezeshk();
            form.flag = true;
            form.ShowDialog(); // or form.ShowDialog(this);
        }

        private void sabtpezeshk_Load(object sender, EventArgs e)
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
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idP = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value);
        }

        private void buttonItem2_Click(object sender, EventArgs e)//edite
        {
            if (idP > 0)
            {
                flag = false;
                moshakhsat_pezeshk form = new moshakhsat_pezeshk();
                form.flag = false;
                form.idP = idP;
                form.ShowDialog(); // or form.ShowDialog(this);

            }
            else
            {
                MessageBox.Show("لطفا یک ردیف انتخاب کنید");
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)//delet
        {
            if (idP > 0)
            {
                MessageBox.Show(bll.Delet(idP));
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
    }
}
