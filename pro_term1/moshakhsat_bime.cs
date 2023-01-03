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
    public partial class moshakhsat_bime : Form
    {
        public moshakhsat_bime()
        {
            InitializeComponent();
        }
        public Form form = new Form();
        bime_BLL bibll = new bime_BLL();
        public bool flag;
        public int idbi;
        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void moshakhsat_bime_Load(object sender, EventArgs e)
        {
            PersianDateTime now = PersianDateTime.Now;
            TimeSpan persianTime = now.TimeOfDay;
            string persianFullDateTime = now.ToString("hh:mm"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
           // bPersianCalenderTextBox1.Today_Click(null, null);
            if (flag)
            {
                guna2TextBox1.Text = (Convert.ToString(bibll.Number() + 1001));
            }



            else if (!flag)
            {
                bime Bi = bibll.Read(idbi);
                guna2TextBox1.Text = Convert.ToString(Bi.codbime);
                guna2TextBox2.Text = Bi.name;
                guna2TextBox3.Text = Convert.ToString(Bi.tarefeomomi);
                guna2TextBox4.Text =Convert.ToString(Bi.tarefemotakhses);
                guna2TextBox5.Text = Convert.ToString(Bi.codbime_marcaz);
                richTextBoxEx1.Text = Bi.what;

                //
                guna2Button3.Text = "ویرایش";

            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            bime Bi = new bime();

            Bi.codbime = Convert.ToInt32(guna2TextBox1.Text);
            Bi.name = guna2TextBox2.Text;
            Bi.tarefeomomi = Convert.ToInt32(guna2TextBox3.Text);
            Bi.tarefemotakhses =Convert.ToInt32(guna2TextBox4.Text);
            Bi.codbime_marcaz =Convert.ToInt32(guna2TextBox5.Text);
            Bi.what = richTextBoxEx1.Text;
            if (flag)
            {
                //Create
                MessageBox.Show(bibll.Create(Bi));
                //رفرش دیتا گرید
                ((sabtbime)Application.OpenForms["sabtbime"]).dataGridViewX1.DataSource = bibll.Read().ToList(); ;
                this.Close();


            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bibll.Update(idbi, Bi));
                //رفرش دیتا گرید 
                ((sabtbime)Application.OpenForms["sabtbime"]).dataGridViewX1.DataSource = bibll.Read().ToList(); ;
                this.Close();
            }

        }
    }
}
